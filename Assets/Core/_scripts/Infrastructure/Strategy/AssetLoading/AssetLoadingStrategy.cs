using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure
{
    public sealed class AssetLoadingStrategy : IAssetLoadingStrategy
    {
        public async UniTask<GameObject> InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink)
        {
            return GameObject.Instantiate(await assetLink.ToUniTask());
        }
    }
}
