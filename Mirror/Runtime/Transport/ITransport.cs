using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Mirror.Runtime.Common;
#if NETSTANDARD
using UnityEngine.Events;
#endif

namespace Mirror.Runtime.Transport
{
    public interface ITransport : INetworkBase
    {
#if NETSTANDARD
        public class ConnectEvent : UnityEvent<IConnection> { }

        /// <summary>
        /// Event that gets fired when a client is accepted by the transport
        /// </summary>
        public ConnectEvent Connected = new ConnectEvent();

        /// <summary>
        /// Raised when the transport starts
        /// </summary>
        public UnityEvent Started = new UnityEvent();
#else
        /// <summary>
        /// Event that gets fired when a client is accepted by the transport
        /// </summary>
        public Action<IConnection> Connected { get; set; }

        /// <summary>
        /// Raised when the transport starts
        /// </summary>
        public Action Started { set; }
#endif
        public IEnumerable<string> Scheme { get; }

        /// <summary>
        /// Open up the port and listen for connections
        /// Use in servers.
        /// Note the task ends when we stop listening
        /// </summary>
        /// <exception>If we cannot start the transport</exception>
        /// <returns></returns>
        public UniTask ListenAsync();

        /// <summary>
        /// Determines if this transport is supported in the current platform
        /// </summary>
        /// <returns>true if the transport works in this platform</returns>
        public bool Supported { get; }

        /// <summary>
        /// Connect to a server located at a provided uri
        /// </summary>
        /// <param name="uri">address of the server to connect to</param>
        /// <returns>The connection to the server</returns>
        /// <exception>If connection cannot be established</exception>
        public UniTask<IConnection> ConnectAsync(Uri uri);

        /// <summary>
        /// Retrieves the address of this server.
        /// Useful for network discovery
        /// </summary>
        /// <returns>the url at which this server can be reached</returns>
        public IEnumerable<Uri> ServerUri();
    }
}
