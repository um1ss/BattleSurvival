using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;

public sealed class GameLifetimeScope : LifetimeScope
{
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] Canvas _canvas;
    [SerializeField] Camera _camera;
    protected override void Configure(IContainerBuilder builder)
    {
        #region GlobalObjects
        builder.RegisterComponentInNewPrefab(_eventSystem, Lifetime.Singleton)
            .DontDestroyOnLoad();
        builder.RegisterComponentInNewPrefab(_canvas, Lifetime.Singleton)
            .DontDestroyOnLoad();
        builder.RegisterComponentInNewPrefab(_camera, Lifetime.Singleton)
            .DontDestroyOnLoad();
        #endregion

        #region IAssetLoadingStrategy
        builder.Register<AssetLoadingStrategy>(Lifetime.Singleton);
        builder.Register<DontDestroyAssetLoadingStrategy>(Lifetime.Singleton);
        #endregion

        #region Services
        builder.Register<ISceneTransitionService, SceneTransitionService>(Lifetime.Singleton);
        builder.Register<IAssetLoadingService, AssetLoadingService>(Lifetime.Singleton);
        builder.Register<IUIService, UIService>(Lifetime.Singleton);
        #endregion

        Debug.Log($"{this.GetType().Name}: registered all dependencies");

        builder.RegisterEntryPoint<BootstrapEntryPoint>(Lifetime.Singleton);
    }
}

