using System;
using UnityEngine;

namespace Scipts
{
    public class Singleton<T> where T : class, new()
    {
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = Activator.CreateInstance<T>();
                    (m_Instance as Singleton<T>)?.OnInit();
                }

                return m_Instance;
            }
        }

        private static T m_Instance;

        protected virtual void OnInit()
        {
            
        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}