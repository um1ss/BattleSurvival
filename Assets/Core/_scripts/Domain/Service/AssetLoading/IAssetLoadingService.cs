using Cysharp.Threading.Tasks;
using UnityEngine;
using DenisKim.Core.Infrastructure;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Domain
{
    public interface IAssetLoadingService
    {
        UniTask<GameObject> InstantiateGameObject(IAssetLoadingStrategy assetLoadingStrategy,
            AsyncOperationHandle<GameObject> assetLink);
        UniTask<GameObject> InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink,
            Transform parent);
        UniTask<AsyncOperationHandle<T>> GetAssetLink<T>(string address);
    }
}
