using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using System.Threading;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Application
{
    public sealed class MainMenuEntryPoint : IAsyncStartable
    {
        readonly IUIService _uiService;

        [Inject]
        public MainMenuEntryPoint(IUIService uiService)
        {
            _uiService = uiService;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _uiService.ShowPersistentPanel(Panels.MainMenu, "MainMenuPanel", new MainMenuPanelLifetimeScope());
        }
    }
}

