using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;
using DenisKim.Core.Infrastructure;
using DenisKim.Core.Domain;

sealed public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] Camera _cameraPrefab;
    [SerializeField] Canvas _canvasPrefab;
    [SerializeField] EventSystem _eventSystemPrefab;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInNewPrefab(_cameraPrefab, Lifetime.Singleton)
            .DontDestroyOnLoad();
        builder.RegisterComponentInNewPrefab(_canvasPrefab, Lifetime.Singleton)
            .DontDestroyOnLoad();
        builder.RegisterComponentInNewPrefab(_eventSystemPrefab, Lifetime.Singleton)
            .DontDestroyOnLoad();

        builder.Register<LoadedScene>(Lifetime.Singleton);
        builder.Register<SceneLoader>(Lifetime.Singleton);
        
        Debug.Log($"{this.GetType().Name}: registered all dependencies");
        
        builder.RegisterEntryPoint<BootstrapEntryPoint>(Lifetime.Singleton);
    }
}

