using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer;
using VContainer.Unity;
using DenisKim.Core.Infrastructure;

sealed public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        #region IAssetLoadingStrategy
        builder.Register<AssetLoadingStrategy>(Lifetime.Singleton);
        builder.Register<DontDestroyOnLoadAssetLoadingStrategy>(Lifetime.Singleton);
        #endregion

        #region Services
        builder.Register<ISceneTransitionService, SceneTransitionService>(Lifetime.Singleton);
        builder.Register<IAssetLoadingService, AssetLoadingService>(Lifetime.Singleton);
        //builder.Register<IUIService, UIService>(Lifetime.Singleton);
        #endregion

        Debug.Log($"{this.GetType().Name}: registered all dependencies");

        builder.RegisterEntryPoint<BootstrapEntryPoint>(Lifetime.Singleton).As<IAsyncStartable>();
    }
}

