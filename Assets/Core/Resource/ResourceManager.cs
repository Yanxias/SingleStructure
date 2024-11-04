using Scipts;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Core.Resource
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        public T Load<T>(string path) where T : UnityEngine.Object
        {
#if UNITY_EDITOR
            //todo resouces.load 代理地址
            return Resources.Load<T>(path);
#else
            m_DepthGenShader = GameResourceManager.GetInstance().LoadShader("Shaders/Ro/WaterDepth/RenderDepth.shader");
#endif
        }

        // public T LoadAsset<T>(string path) where T : Asset
        // {
        //     return
        // }
    }
}