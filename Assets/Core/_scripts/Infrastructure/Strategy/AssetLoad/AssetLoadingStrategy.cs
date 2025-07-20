using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DenisKim.Core.Infrastructure
{
    public sealed class AssetLoadingStrategy : IAssetLoadingStrategy
    {
        public async UniTask InstantiateAsync(string address)
        {
            await Addressables.InstantiateAsync(address);
        }

        public async UniTask InstantiateAsync(string address, Transform parent)
        {
            await Addressables.InstantiateAsync(address, parent);
        }
    }
}
