using System;
using System.Net;
using Cysharp.Threading.Tasks;

namespace Mirror.Runtime.Common
{
    /// <summary>
    /// An object that can send and receive messages
    /// </summary>
    public interface IMessageHandler
    {
        void RegisterHandler<T>(Action<INetworkConnection, T> handler);

        void RegisterHandler<T>(Action<T> handler);

        void UnregisterHandler<T>();

        void ClearHandlers();

        void Send<T>(T msg, byte channelId = (byte)Channels.Reliable);

        UniTask SendAsync<T>(T msg, byte channelId = (byte) Channels.Reliable);

        UniTask SendAsync(ArraySegment<byte> segment, byte channelId = (byte) Channels.Reliable);

        UniTask ProcessMessagesAsync();

        /// <summary>
        /// Sends a message, but notify when it is delivered or lost
        /// </summary>
        /// <typeparam name="T">type of message to send</typeparam>
        /// <param name="msg">message to send</param>
        /// <param name="token">a arbitrary object that the sender will receive with their notification</param>
        void SendNotify<T>(T msg, object token, byte channelId = (byte) Channels.Unreliable);

        /// <summary>
        /// Raised when a message is delivered
        /// </summary>
        event Action<INetworkConnection, object> NotifyDelivered;

        /// <summary>
        /// Raised when a message is lost
        /// </summary>
        event Action<INetworkConnection, object> NotifyLost;

    }

    /// <summary>
    /// An object that can observe NetworkIdentities.
    /// this is useful for interest management
    /// </summary>
    public interface IVisibilityTracker
    {
#if FIX
        void AddToVisList(NetworkIdentity identity);
        void RemoveFromVisList(NetworkIdentity identity);
        void RemoveObservers();
#endif
    }

    /// <summary>
    /// An object that can own networked objects
    /// </summary>
    public interface IObjectOwner
    {
#if FIX
        NetworkIdentity Identity { get; set; }
        void RemoveOwnedObject(NetworkIdentity networkIdentity);
        void AddOwnedObject(NetworkIdentity networkIdentity);
        void DestroyOwnedObjects();
#endif
    }
    /// <summary>
    /// A connection to a remote endpoint.
    /// May be from the server to client or from client to server
    /// </summary>
    public interface INetworkConnection : INetworkBase, IMessageHandler, IVisibilityTracker, IObjectOwner
    {
        /// <summary>
        ///     Whether or not the network connection is ready to send and receive data.
        /// </summary>
        bool IsReady { get; set; }

        /// <summary>
        ///     The address endpoint of this network connection.
        /// </summary>
        EndPoint Address { get; }

        /// <summary>
        ///     Data that can be sent or receive during network initial connection.
        /// </summary>
        object AuthenticationData { get; set; }
    }
}
