using System;
using UnityEngine;

namespace Scipts
{
    public class Singleton<T> where T : class, new()
    {
        public T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = Activator.CreateInstance<T>();
                    (m_Instance as Singleton<T>)?.Init();
                }

                return m_Instance;
            }
        }

        private T m_Instance;

        public void Init()
        {
            
        }
    }
}