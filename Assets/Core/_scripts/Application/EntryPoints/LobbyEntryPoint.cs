using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using System.Threading;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Application
{
    public sealed class LobbyEntryPoint : IAsyncStartable
    {
        readonly IUIService _uIService;

        [Inject]
        public LobbyEntryPoint(IUIService uIService)
        {
            _uIService = uIService;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _uIService.ShowPersistentPanel(Panels.Lobby, "LobbyPanel", new LobbyPanelLifetimeScope());
        }
    }
}