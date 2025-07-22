using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure
{
    public interface IAssetLoadingStrategy
    {
        UniTask InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink);
        UniTask InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink, Transform parent);
    }
}
