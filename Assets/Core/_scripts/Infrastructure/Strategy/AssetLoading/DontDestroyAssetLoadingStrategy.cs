using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure
{
    public sealed class DontDestroyAssetLoadingStrategy : IAssetLoadingStrategy
    {
        public async UniTask<GameObject> InstantiateGameObject(AsyncOperationHandle<GameObject> assetLink)
        {
            var instance = GameObject.Instantiate(await assetLink.ToUniTask());
            Object.DontDestroyOnLoad(instance);
            return instance;
        }
    }
}