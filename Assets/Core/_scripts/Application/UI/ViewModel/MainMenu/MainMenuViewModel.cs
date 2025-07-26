using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using VContainer;

namespace DenisKim.Core.Application
{
    public sealed class MainMenuViewModel : AbstractViewModel
    {
        readonly ISceneTransitionService _sceneTransitionService;

        [Inject]
        public MainMenuViewModel(ISceneTransitionService sceneTransitionService)
        {
            _sceneTransitionService = sceneTransitionService;
        }

        public async UniTask TransitionScene(int sceneId)
        {
            await _sceneTransitionService.Load(sceneId);
        }
    }
}
