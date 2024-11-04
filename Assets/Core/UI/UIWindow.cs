using System;
using UnityEngine;

namespace Scipts
{
    public class UIWindow : MonoBehaviour
    {
        public string Name => gameObject.name;
        
        public virtual string PrefabPath => String.Empty;
        
        public virtual void OnInit()
        {
        }

        public virtual void OnDestroy()
        {
        }

        public virtual void OnOpen()
        {
            transform.SetAsLastSibling();
        }

        public virtual void OnClose()
        {
        }
        
    }
}