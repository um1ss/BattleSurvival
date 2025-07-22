using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using System.Threading;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class BootstrapEntryPoint : IAsyncStartable
{
    const int MAIN_MENU_SCENE_INDEX = 1;
    readonly ISceneTransitionService _sceneTransitionService;
    readonly IAssetLoadingService _assetLoadingService;
    readonly DontDestroyAssetLoadingStrategy _dontDestroyOnLoadAssetLoadingStrategy;
    readonly SceneTransitionStrategy _sceneTransitionStrategy;

    [Inject]
    public BootstrapEntryPoint(ISceneTransitionService sceneLoaderContext, IAssetLoadingService assetLoadContext,
        SceneTransitionStrategy sceneTransitionStrategy,
        DontDestroyAssetLoadingStrategy dontDestroyOnLoadAssetLoadingStrategy)
    {
        _dontDestroyOnLoadAssetLoadingStrategy = dontDestroyOnLoadAssetLoadingStrategy;
        _sceneTransitionStrategy = sceneTransitionStrategy;
        _assetLoadingService = assetLoadContext;
        _sceneTransitionService = sceneLoaderContext;
    }

    public async UniTask StartAsync(CancellationToken cancellationToken)
    {
        await _assetLoadingService.InstantiateGameObject(_dontDestroyOnLoadAssetLoadingStrategy, 
            await _assetLoadingService.GetAssetLink<GameObject>("Assets/Core/Prefabs/GameLifetimeScope/EventSystem.prefab"));
        await _assetLoadingService.InstantiateGameObject(_dontDestroyOnLoadAssetLoadingStrategy, 
            await _assetLoadingService.GetAssetLink<GameObject>("Assets/Core/Prefabs/GameLifetimeScope/Main Camera.prefab"));
        await _assetLoadingService.InstantiateGameObject(_dontDestroyOnLoadAssetLoadingStrategy, 
            await _assetLoadingService.GetAssetLink<GameObject>("Assets/Core/Prefabs/GameLifetimeScope/Canvas.prefab"));

        await _sceneTransitionService.Load(_sceneTransitionStrategy, MAIN_MENU_SCENE_INDEX);
    }
}
