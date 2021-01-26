#if NETSTANDARD
using UnityEngine;
#endif

namespace Mirror.Runtime.Server
{
#if NETSTANDARD
    public class NetworkServer : MonoBehaviour
#else
    public class NetworkServer
#endif
    {
    }
}
