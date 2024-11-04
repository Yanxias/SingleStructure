using System.Collections.Generic;
using Core.Resource;
using UnityEngine;

namespace Scipts
{
    public class UIManager : Singleton<UIManager>
    {
        #region Fields

        private Dictionary<string, UIWindow> m_OpeningWindow;

        private Dictionary<string, UIWindow> m_CacheWindow;

        /// <summary>
        /// 某些情况需要把当前的UI都隐藏，之后再原样修复
        /// </summary>
        private Stack<UIWindow> m_CacheHistoryWindow;

        private Dictionary<UILayer, GameObject> m_LayerMap;

        #endregion

        #region Interface

        public void OpenWindow<T>(string path, object param) where T : UIWindow
        {
            string windowName = typeof(T).Name;
            if (m_OpeningWindow.ContainsKey(windowName))
            {
                Debug.LogError($"UIManager Error - OpenWindow: window {windowName} has been opened!!");
                return;
            }
            if (m_CacheWindow.ContainsKey(windowName))
            {
                UIWindow cacheWindow =  m_CacheWindow[windowName];
                cacheWindow.OnOpen();
                m_CacheWindow.Remove(windowName);
                m_OpeningWindow.Add(windowName, cacheWindow);
                return;
            }
            GameObject obj = ResourceManager.Instance.Load<GameObject>(path);
            obj.name = windowName;
            UIWindow window = obj.GetComponent<UIWindow>();
            window.OnInit();
            window.OnOpen();
            m_OpeningWindow.Add(windowName, window);
        }

        public void CloseWindow<T>() where T : UIWindow
        {
            string windowName = typeof(T).Name;
            if (!m_OpeningWindow.ContainsKey(windowName))
            {
                Debug.LogError($"UIManager Error - CloseWindow: window {windowName} doesnt exist!!");
                return;
            }

            UIWindow window = m_OpeningWindow[windowName];
            window.OnClose();
            m_OpeningWindow.Remove(windowName);
            m_CacheWindow.Add(windowName, window);
        }

        #endregion

        protected override void OnInit()
        {
            base.OnInit();
            m_OpeningWindow = new Dictionary<string, UIWindow>();
            m_CacheWindow = new Dictionary<string, UIWindow>();
        }
    }

    
}