using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.LifetimScope
{
    public sealed class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] EventSystem _eventSystem;
        [SerializeField] Canvas _canvas;
        [SerializeField] Camera _camera;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_eventSystem, Lifetime.Singleton)
                .DontDestroyOnLoad();
            builder.RegisterComponentInNewPrefab(_canvas, Lifetime.Singleton)
                .DontDestroyOnLoad();
            builder.RegisterComponentInNewPrefab(_camera, Lifetime.Singleton)
                .DontDestroyOnLoad();
            builder.Register<ShowPersistentPanelStrategy>(Lifetime.Singleton);
            builder.Register<ShowOnDemandLoadingPanelStrategy>(Lifetime.Singleton);
            builder.Register<IUIService, UIService>(Lifetime.Singleton);
            builder.Register<ISceneTransitionService, SceneTransitionService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<BootstrapEntryPoint>(Lifetime.Singleton);
        }
    }
}
