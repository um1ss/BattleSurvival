using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;

public class BootstrapEntryPoint : IAsyncStartable
{
    const int MAIN_MENU_SCENE_INDEX = 1;
    readonly EventSystem _eventSystem;
    readonly Canvas _canvas;
    readonly Camera _camera;
    readonly ISceneTransitionService _sceneTransitionService;
    readonly IUIService _uiService;

    [Inject]
    public BootstrapEntryPoint(EventSystem eventSystem,
        Canvas canvas,
        Camera camera,
        ISceneTransitionService sceneLoaderContext,
        IAssetLoadingService assetLoadContext,
        DontDestroyAssetLoadingStrategy dontDestroyOnLoadAssetLoadingStrategy,
        IUIService uiService)
    {
        _eventSystem = eventSystem;
        _canvas = canvas;
        _camera = camera;
        _uiService = uiService;
        _sceneTransitionService = sceneLoaderContext;
    }

    public async UniTask StartAsync(CancellationToken cancellationToken)
    {
        await _uiService.AddPanelDictionary(PanelsEnum.MainMenu, "MainMenu");

        await _sceneTransitionService.Load(MAIN_MENU_SCENE_INDEX);
    }
}
