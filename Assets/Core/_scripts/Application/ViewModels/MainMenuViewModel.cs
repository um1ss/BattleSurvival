using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using R3;
using System;
using VContainer;

namespace DenisKim.Core.Application
{
    public sealed class MainMenuViewModel : IDisposable
    {
        public ReactiveCommand<int> TransitionToLobbyCommand { get; }
        public ReactiveCommand ShowPanel { get; }

        readonly ISceneTransitionService _sceneTransitionService;
        readonly IUIService _uIService;

        CompositeDisposable _disposables;

        [Inject]
        public MainMenuViewModel(ISceneTransitionService sceneTransitionService, IUIService uIService)
        {
            _sceneTransitionService = sceneTransitionService;
            _uIService = uIService;
            _disposables = new CompositeDisposable();
            TransitionToLobbyCommand = new ReactiveCommand<int>().AddTo(_disposables);

            TransitionToLobbyCommand
                .Subscribe(async sceneId =>
                    await _sceneTransitionService.LoadSceneAsync((SceneIndex)sceneId))
                .AddTo(_disposables);
            ShowPanel.Subscribe(async _ => await _uIService.ShowOnDemandLoadingPanel)
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}
