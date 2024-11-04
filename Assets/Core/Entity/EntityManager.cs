using System.Collections.Generic;

namespace Scipts
{
    public class EntityManager : Singleton<EntityLogicManager>
    {
        public void CreateEntity<T>(EntityInfo info) where T : Entity
        {
            info.entityId = m_EntityId;
            m_EntityId++;
            Entity newEntity =  new Entity(info);
            
        }

        private void GetEntityFromPool(Entity entity)
        {
            
        }

        #region Fields

        private int m_EntityId = 0;

        private List<Entity> m_Entity;

        private List<Entity> m_LoadingEntity;

        #endregion
    }
}