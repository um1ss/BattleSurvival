using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;
using DenisKim.Core.Domain;

public class BootstrapEntryPoint : IStartable
{
    readonly Camera _camera;
    readonly EventSystem _eventSystem;
    readonly Canvas _canvas;

    readonly SceneLoader _sceneLoader;
    
    [Inject]
    public BootstrapEntryPoint(Camera camera, EventSystem eventSystem, Canvas canvas,
        SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
        _camera = camera;
        _eventSystem = eventSystem;
        _canvas = canvas;
    }

    public void Start()
    {
        _sceneLoader.Load();
    }
}