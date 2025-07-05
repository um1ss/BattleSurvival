using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;
using DenisKim.Insfrastructure;

public class BootstrapEntryPoint : IStartable
{
    readonly LifetimeScope _rootLifetimeScope;

    readonly Camera _camera;
    readonly EventSystem _eventSystem;
    readonly Canvas _canvas;

    readonly ISceneLoader _sceneLoader;
    
    [Inject]
    public BootstrapEntryPoint(Camera camera, EventSystem eventSystem, Canvas canvas,
        ISceneLoader sceneLoader, LifetimeScope rootLifetimeScope)
    {
        _rootLifetimeScope = rootLifetimeScope;
        _sceneLoader = sceneLoader;
        _camera = camera;
        _eventSystem = eventSystem;
        _canvas = canvas;
    }

    public void Start()
    {
        _sceneLoader.LoadSceneAsync(_rootLifetimeScope, "MainMenu");
    }
}