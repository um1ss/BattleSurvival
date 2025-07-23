using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure
{
    public interface IAssetLoadingStrategy
    {
        UniTask<GameObject> InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink);
    }
}
