using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

namespace Core.Event
{
    public class EventManager : Scipts.Singleton<EventManager>
    {
        #region Interface

        public void FireEvent(EventType type, Object param)
        {
            if (m_EventCallBack.ContainsKey(type))
            {
                foreach (var callback in m_EventCallBack[type])
                {
                    callback?.Invoke(param);
                }
            }
            else
            {
                Debug.LogError($"EventManager Error - FireEvent: EventType {type} cant find target callback!!");
            }
        }

        public void RegisterEvent(EventType type, Action<Object> callBack)
        {
            if (!m_EventCallBack.ContainsKey(type))
            {
                m_EventCallBack.Add(type, new List<Action<object>>());
            }
            m_EventCallBack[type].Add(callBack);
        }

        public void UnRegisterEvent(EventType type, Action<Object> callBack)
        {
            if (!m_EventCallBack.ContainsKey(type))
            {
                Debug.LogError($"EventManager Error - UnRegisterEvent: EventType {type} cant find target callback!!");
                return;
            }
            if (!m_EventCallBack[type].Contains(callBack))
            {
                Debug.LogError($"EventManager Error - UnRegisterEvent: EventType {type} target callback has been removed!!");
                return;
            }
            m_EventCallBack[type].Remove(callBack);
        }

        #endregion

        #region Methods

        protected override void OnInit()
        {
            m_EventCallBack = new Dictionary<EventType, List<Action<object>>>();
        }

        protected override void OnDestroy()
        {
            m_EventCallBack.Clear();
            m_EventCallBack = null;
        }

        #endregion

        #region Fields

        private Dictionary<EventType, List<Action<Object>>> m_EventCallBack;

        #endregion
    }
}