using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure
{
    public sealed class DontDestroyAssetLoadingStrategy : IAssetLoadingStrategy
    {
        public async UniTask InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink)
        {
            var instance = GameObject.Instantiate(await assetLink.ToUniTask());
            Object.DontDestroyOnLoad(instance);
        }

        public async UniTask InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink, Transform parent)
        {
            var instance = GameObject.Instantiate(await assetLink.ToUniTask(), parent);
            Object.DontDestroyOnLoad(instance);
        }
    }
}