using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;
using UnityEngine;
using VContainer;

namespace DenisKim.Core.Domain
{
    public sealed class AssetLoadingService : BaseService, IAssetLoadingService
    {
        private IAssetLoadingStrategy _currentStrategy;

        [Inject]
        public AssetLoadingService(AssetLoadingStrategy strategy) : base(strategy)
        {
            _currentStrategy = strategy;
        }

        public override void ChangeBehavior(IStrategy newBehavior)
        {
            _currentStrategy = (IAssetLoadingStrategy)newBehavior;
        }

        public UniTask InstantiateObject(string address)
        {
            return _currentStrategy.InstantiateAsync(address);
        }

        public UniTask InstantiateObject(string address, Transform parent)
        {
            return _currentStrategy.InstantiateAsync(address, parent);
        }
    }
}
