using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DenisKim.Core.Domain
{
    public interface IAssetLoadingService : IService
    {
        UniTask InstantiateObject(string address);
        UniTask InstantiateObject(string address, Transform parent);
    }
}
