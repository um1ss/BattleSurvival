using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using System;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Application
{
    public sealed class SettingsViewModel : IDisposable
    {
        readonly IUIService _iUIService;

        [Inject]
        public SettingsViewModel(IUIService uIService)
        {
            _iUIService = uIService;
        }
        public async UniTask ShowPanel(IShowPanelStrategy showPanelStrategy, Panels panel, string address,
            IInstaller scope) => await _iUIService.ShowPanel(showPanelStrategy, panel, address, scope);

        public void HidePanel() => _iUIService.HidePanel();
        public void Dispose()
        {

        }
    }
}