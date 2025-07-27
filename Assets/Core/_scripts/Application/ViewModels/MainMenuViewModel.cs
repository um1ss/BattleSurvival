using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using R3;
using System;
using UnityEngine.Video;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Application
{
    public sealed class MainMenuViewModel : IDisposable
    {
        readonly ISceneTransitionService _sceneTransitionService;
        readonly IUIService _iUIService;

        CompositeDisposable _disposables;

        [Inject]
        public MainMenuViewModel(ISceneTransitionService sceneTransitionService, IUIService uIService)
        {
            _sceneTransitionService = sceneTransitionService;
            _iUIService = uIService;
        }

        public async UniTask ShowPanel(IShowPanelStrategy showPanelStrategy, Panels panel, string address,
            IInstaller scope)
        {
            await _iUIService.ShowPanel(showPanelStrategy, panel, address, scope);
        }

        public void LoadSceneAsync()
        {
            _sceneTransitionService.LoadSceneAsync(SceneIndex.Lobby);
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}
