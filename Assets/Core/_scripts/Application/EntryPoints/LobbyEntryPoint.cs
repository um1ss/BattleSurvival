using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using System.Threading;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Application
{
    public sealed class LobbyEntryPoint : IAsyncStartable
    {
        readonly ShowPersistentPanelStrategy _showPersistentPanelStrategy;
        readonly IUIService _uIService;

        [Inject]
        public LobbyEntryPoint(ShowPersistentPanelStrategy showPersistentPanelStrategy,
            IUIService uIService)
        {
            _showPersistentPanelStrategy = showPersistentPanelStrategy;
            _uIService = uIService;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _uIService.ShowPanel(_showPersistentPanelStrategy,
                Panels.Lobby, "LobbyPanel", new LobbyPanelLifetimeScope());
        }
    }
}