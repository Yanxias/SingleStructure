using System;
using System.Collections.Generic;
using UnityEngine;
using Type = System.Type;

namespace Scipts.Pool
{
    public class PoolManager : Singleton<PoolManager>
    {
        public PoolBase GetPool<T>() where T : IPoolObject
        {
            if (HasObjectPool(typeof(T)))
            {
                Debug.LogError($"PoolManager Error - GetPool<T>: pool of {typeof(T)} exist!!");
                return null;
            }

            IPoolObject template = Activator.CreateInstance<T>();
            PoolBase objectPool = new PoolBase(template);
            m_ObjectPools.Add(typeof(T), objectPool);
            return objectPool;
        }

        public bool HasObjectPool(Type poolType)
        {
            return InternalHasObjectPool(poolType);
        }

        #region Methods

        private bool InternalHasObjectPool(Type poolType)
        {
            return m_ObjectPools.ContainsKey(poolType);
        }

        #endregion

        private List<PoolBase> m_AllPool; 

        private Dictionary<Type, PoolBase> m_ObjectPools;
        
    }
}