using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public sealed class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        #region ISceneTransitionStrategy
        builder.Register<SceneTransitionStrategy>(Lifetime.Singleton);
        #endregion

        #region IAssetLoadingStrategy
        builder.Register<AssetLoadingStrategy>(Lifetime.Singleton);
        builder.Register<DontDestroyAssetLoadingStrategy>(Lifetime.Singleton);
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

