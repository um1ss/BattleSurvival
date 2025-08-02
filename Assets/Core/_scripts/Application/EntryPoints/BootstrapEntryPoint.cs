using Cysharp.Threading.Tasks;
using DenisKim.Core;
using DenisKim.Core.Domain;
using System.Threading;
using VContainer;
using VContainer.Unity;

public class BootstrapEntryPoint : IAsyncStartable
{
    readonly ISceneTransitionService _sceneTransitionService;
    readonly IEventSystemService _eventSystemService;
    readonly ICanvasService _canvasService;
    readonly ICameraService _cameraService;

    [Inject]
    public BootstrapEntryPoint(IEventSystemService eventSystemService,
        ICanvasService canvasService,
        ICameraService cameraService,
        ISceneTransitionService sceneLoaderService)
    {
        _eventSystemService = eventSystemService;
        _canvasService = canvasService;
        _cameraService = cameraService;
        _sceneTransitionService = sceneLoaderService;
    }

    public async UniTask StartAsync(CancellationToken cancellationToken)
    {
        await _eventSystemService.CreateInstance("EventSystem");
        await _canvasService.CreateInstance("Canvas");
        await _cameraService.CreateInstance("Camera");
        await _sceneTransitionService.LoadSceneAsync(SceneIndex.MainMenu);
    }
}
