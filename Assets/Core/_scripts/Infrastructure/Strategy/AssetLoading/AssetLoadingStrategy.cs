using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure
{
    public sealed class AssetLoadingStrategy : IAssetLoadingStrategy
    {
        public async UniTask InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink)
        {
            GameObject.Instantiate(await assetLink.ToUniTask());
        }

        public async UniTask InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink, Transform parent)
        {
            GameObject.Instantiate(await assetLink.ToUniTask(), parent);
        }
    }
}
