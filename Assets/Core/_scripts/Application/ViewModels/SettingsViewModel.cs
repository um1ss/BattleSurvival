using DenisKim.Core.Domain;
using R3;
using VContainer;

namespace DenisKim.Core.Application
{
    public sealed class SettingsViewModel : BaseViewModel
    {
        readonly IUIService _iUIService;

        public ReactiveCommand<Unit> OnClosePanel { get; }

        [Inject]
        public SettingsViewModel(IUIService uIService)
        {
            _iUIService = uIService;

            OnClosePanel = new();

            OnClosePanel.Subscribe(_ => _iUIService.HidePanel()).AddTo(_compositeDisposable);
        }
    }
}