using System;
using Mirror.Runtime.Client;
using Mirror.Runtime.Common;

namespace Mirror.Runtime.Server
{
    public interface IServerObjectManager
    {
        bool AddPlayerForConnection(INetworkConnection conn, Object player);

        bool AddPlayerForConnection(INetworkConnection conn, Object player, Guid assetId);

        bool ReplacePlayerForConnection(INetworkConnection conn, NetworkClient client, Object player, bool keepAuthority = false);

        bool ReplacePlayerForConnection(INetworkConnection conn, NetworkClient client, Object player, Guid assetId, bool keepAuthority = false);

        void Spawn(Object obj, Object ownerPlayer);

        void Spawn(Object obj, INetworkConnection ownerConnection = null);

        void Spawn(Object obj, Guid assetId, INetworkConnection ownerConnection = null);

        void Destroy(Object obj);

        void UnSpawn(Object obj);

        bool SpawnObjects();
    }

    public interface INetworkServer : INetworkBase
    {
        /// <summary>
        ///     Add network connection to server.
        /// </summary>
        /// <param name="conn">The specific connection we want to add to server.</param>
        void AddConnection(INetworkConnection conn);

        /// <summary>
        ///     Remove network con nection from server.
        /// </summary>
        /// <param name="conn">The specific connection we want to remove from server.</param>
        void RemoveConnection(INetworkConnection conn);

        /// <summary>
        ///     Send byte data to all clients.
        /// </summary>
        /// <typeparam name="T">The type of message we want to send to all clients.</typeparam>
        /// <param name="msg">The message data to send to clients.</param>
        /// <param name="channelId">The channel to send data on.</param>
        void SendToAll<T>(T msg, byte channelId = (byte) Channels.Reliable);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The type of message we want to send to all clients.</typeparam>
        /// <param name="identity">The <see cref="NetworkIdentity"/> of the object that we are sending data from.</param>
        /// <param name="msg">The message data to send to client.</param>
        /// <param name="channelId">The channel to send data on.</param>
        void SendToClientOfPlayer<T>(NetworkIdentity identity, T msg, byte channelId = (byte) Channels.Reliable);

    }
}
