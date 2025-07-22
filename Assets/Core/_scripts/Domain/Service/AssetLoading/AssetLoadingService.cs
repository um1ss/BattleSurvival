using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Domain
{
    public sealed class AssetLoadingService : IAssetLoadingService
    {
        public async UniTask<AsyncOperationHandle<T>> GetAssetLink<T>(string address)
        {
            var handle = Addressables.LoadAssetAsync<T>(address);
            await handle.ToUniTask();
            return handle;
        }

        public async UniTask InstantiateGameObject(IAssetLoadingStrategy assetLoadingStrategy,
            AsyncOperationHandle<GameObject> assetLink)
        {
            await assetLoadingStrategy.InstantiateGameObject(assetLink);
        }

        public async UniTask InstantiateGameObject(IAssetLoadingStrategy assetLoadingStrategy,
            AsyncOperationHandle<GameObject> assetLink,
            Transform parent)
        {
            await assetLoadingStrategy.InstantiateGameObject(assetLink, parent);
        }
    }
}
