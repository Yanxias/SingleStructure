using System.Collections.Generic;

namespace Scipts.Pool
{
    public class PoolBase
    {
        public PoolBase(IPoolObject template)
        {
            m_ObjectTemplate = template;
        }

        public void Destroy()
        {
            m_ObjectTemplate = null;
            foreach (var poolObject in m_AllObjects)
            {
                poolObject.Delete();
            }

            m_AllObjects = null;
        }
        
        public IPoolObject TryGetObject()
        {
            foreach (var obj in m_AllObjects)
            {
                if (obj.IsActive())
                    return obj;
            }

            IPoolObject newObject = m_ObjectTemplate.GetClone();
            newObject.Initialize();
            newObject.SetActive(true);
            m_AllObjects.Add(newObject);
            return newObject;
        }

        public void RecycleObject(IPoolObject poolObject)
        {
            poolObject.SetActive(false);
            poolObject.Recycle();
        }

        public void DeleteObject(IPoolObject poolObject)
        {
            m_AllObjects.Remove(poolObject);
            poolObject.Delete();
        }
        
        /// <summary>
        /// 根据生命周期delete object
        /// </summary>

        private List<IPoolObject> m_AllObjects;

        private IPoolObject m_ObjectTemplate;
    }

    public interface IPoolObject
    {
        public bool IsActive();

        public void SetActive(bool active);
        
        public void Initialize();

        public void Recycle();

        public void Delete();

        public IPoolObject GetClone();
    }
}