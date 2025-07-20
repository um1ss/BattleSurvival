using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DenisKim.Core.Infrastructure
{
    public interface IAssetLoadingStrategy : IStrategy
    {
        UniTask InstantiateAsync(string address);
        UniTask InstantiateAsync(string address, Transform parent);
    }
}
