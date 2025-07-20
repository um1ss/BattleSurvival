using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DenisKim.Core.Infrastructure
{
    public sealed class DontDestroyOnLoadAssetLoadingStrategy : IAssetLoadingStrategy
    {
        public async UniTask InstantiateAsync(string address)
        {
            Object.DontDestroyOnLoad(await Addressables.InstantiateAsync(address));
        }

        public async UniTask InstantiateAsync(string address, Transform parent)
        {
            Object.DontDestroyOnLoad(await Addressables.InstantiateAsync(address, parent));
        }
    }
}