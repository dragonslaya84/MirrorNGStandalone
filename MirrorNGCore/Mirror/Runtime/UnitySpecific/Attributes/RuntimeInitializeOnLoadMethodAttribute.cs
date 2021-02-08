#if !NETSTANDARD
using System;

namespace Mirror.Mirror.Runtime.UnitySpecific.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RuntimeInitializeOnLoadMethodAttribute : Attribute
    {
        public RuntimeInitializeOnLoadMethodAttribute() => this.loadType = RuntimeInitializeLoadType.AfterSceneLoad;

        public RuntimeInitializeOnLoadMethodAttribute(RuntimeInitializeLoadType loadType) => this.loadType = loadType;

        public RuntimeInitializeLoadType loadType { get; private set; }
    }
}
#endif