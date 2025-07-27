using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using System.Threading;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Application
{
    public sealed class MainMenuEntryPoint : IAsyncStartable
    {
        readonly ShowPersistentPanelStrategy _showPersistentPanelStrategy;
        readonly IUIService _uiService;

        [Inject]
        public MainMenuEntryPoint(ShowPersistentPanelStrategy showPersistentPanelStrategy,
            IUIService uiService)
        {
            _showPersistentPanelStrategy = showPersistentPanelStrategy;
            _uiService = uiService;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _uiService.ShowPanel(_showPersistentPanelStrategy, 
                Panels.MainMenu, "MainMenuPanel", new MainMenuPanelLifetimeScope());
        }
    }
}

