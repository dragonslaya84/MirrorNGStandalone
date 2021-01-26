using System;
using Cysharp.Threading.Tasks;
using Mirror.Runtime.Common;

namespace Mirror.Runtime.Client
{
    public delegate NetworkIdentity SpawnHandlerDelegate(SpawnMessage msg);

    // Handles requests to unspawn objects on the client
    public delegate void UnSpawnDelegate(NetworkIdentity spawned);

    public interface IClientObjectManager
    {
        Object GetPrefab(Guid assetId);

        void RegisterPrefab(NetworkIdentity prefab);

        void RegisterPrefab(NetworkIdentity prefab, Guid newAssetId);

        void RegisterPrefab(NetworkIdentity prefab, SpawnHandlerDelegate spawnHandler, UnSpawnDelegate unspawnHandler);

        void UnregisterPrefab(NetworkIdentity prefab);

        void RegisterSpawnHandler(Guid assetId, SpawnHandlerDelegate spawnHandler, UnSpawnDelegate unspawnHandler);

        void UnregisterSpawnHandler(Guid assetId);

        void ClearSpawners();

        void DestroyAllClientObjects();

        void PrepareToSpawnSceneObjects();
    }

    public interface INetworkClient : INetworkBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="channelId"></param>
        void Send<T>(T message, byte channelId = (byte) Channels.Reliable);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        UniTask SendAsync<T>(T message, byte channelId = (byte) Channels.Reliable);
    }
}
