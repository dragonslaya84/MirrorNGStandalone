#if NETSTANDARD
using UnityEngine;
#endif

namespace Mirror.Runtime.Client
{
#if NETSTANDARD
    public class NetworkClient : MonoBehaviour
#else
    public class NetworkClient
#endif
    {
    }
}
