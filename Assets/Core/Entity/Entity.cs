using System.Collections;
using System.Collections.Generic;
using Scipts;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected EntityInfo m_EntityInfo;

    public Entity(EntityInfo info)
    {
        m_EntityInfo = info;
    }
    
    protected virtual void OnInit()
    {
        
    }

    protected virtual void OnShow()
    {
        
    }

    protected virtual void OnHide()
    {
        
    }

    protected virtual void RefreshInfo(EntityInfo info)
    {
        m_EntityInfo = info;
        Refresh();
    }

    protected virtual void Refresh()
    {
        
    }
}
