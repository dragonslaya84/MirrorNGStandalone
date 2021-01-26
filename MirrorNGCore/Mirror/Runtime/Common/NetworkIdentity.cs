#if NETSTANDARD
using UnityEngine;
#endif

namespace Mirror.Runtime.Common
{
#if NETSTANDARD
    public class NetworkIdentity : MonoBehaviour
#else
    public class NetworkIdentity
#endif
    {
    }
}
