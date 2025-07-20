using System.Threading;
using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using VContainer;
using VContainer.Unity;

public class BootstrapEntryPoint : IAsyncStartable
{
    const int MAIN_MENU_SCENE_INDEX = 1;
    readonly ISceneTransitionService _sceneTransitionService;
    readonly IAssetLoadingService _assetLoadingService;
    readonly DontDestroyOnLoadAssetLoadingStrategy _dontDestroyOnLoadAssetLoadingStrategy;
    readonly AssetLoadingStrategy _assetLoadingStrategy;

    [Inject]
    public BootstrapEntryPoint(ISceneTransitionService sceneLoaderContext, IAssetLoadingService assetLoadContext,
        DontDestroyOnLoadAssetLoadingStrategy dontDestroyOnLoadAssetLoadingStrategy,
        AssetLoadingStrategy assetLoadingStrategy)
    {
        _sceneTransitionService = sceneLoaderContext;
        _assetLoadingService = assetLoadContext;
        _dontDestroyOnLoadAssetLoadingStrategy = dontDestroyOnLoadAssetLoadingStrategy;
        _assetLoadingStrategy = assetLoadingStrategy;
    }

    public async UniTask StartAsync(CancellationToken cancellationToken)
    {
        _assetLoadingService.ChangeBehavior(_assetLoadingStrategy);
        await _assetLoadingService.InstantiateObject("Assets/Core/Prefabs/GameLifetimeScope/EventSystem.prefab");
        await _assetLoadingService.InstantiateObject("Assets/Core/Prefabs/GameLifetimeScope/Main Camera.prefab");
        await _assetLoadingService.InstantiateObject("Assets/Core/Prefabs/GameLifetimeScope/Canvas.prefab");

        await _sceneTransitionService.Load(MAIN_MENU_SCENE_INDEX);
    }
}
