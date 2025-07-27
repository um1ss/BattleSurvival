using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;
using VContainer.Unity;

public class BootstrapEntryPoint : IAsyncStartable
{
    readonly ISceneTransitionService _sceneTransitionService;

    [Inject]
    public BootstrapEntryPoint(EventSystem eventSystem,
        Canvas canvas,
        Camera camera,
        ISceneTransitionService sceneLoaderService)
    {
        _sceneTransitionService = sceneLoaderService;
    }

    public async UniTask StartAsync(CancellationToken cancellationToken)
    {
        await _sceneTransitionService.LoadSceneAsync(SceneIndex.MainMenu);
    }
}
