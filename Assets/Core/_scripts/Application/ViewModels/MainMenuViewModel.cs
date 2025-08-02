using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using R3;
using System;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Application
{
    public sealed class MainMenuViewModel : BaseViewModel
    {
        readonly ISceneTransitionService _sceneTransitionService;
        readonly IUIService _uIService;
        readonly ICurrency _hardCurrency;
        readonly ICurrency _softCurrency;

        readonly IShowPanelStrategy _showOnDemandLoadingPanelStrategy;

        public ReadOnlyReactiveProperty<string> HardCurrency { get; }
        public ReadOnlyReactiveProperty<string> SoftCurrency { get; }

        public ReactiveCommand<Unit> OnShowSettingsPanel { get; }
        public ReactiveCommand<Unit> OnLoadLobbySceneAsync { get; }

        [Inject]
        public MainMenuViewModel(ISceneTransitionService sceneTransitionService,
            IUIService uIService,
            HardCurrencyService hardCurrencyService,
            SoftCurrencyService softCurrencyService,
            ShowOnDemandLoadingPanelStrategy showOnDemandLoadingPanelStrategy)
        {
            _sceneTransitionService = sceneTransitionService;
            _uIService = uIService;
            _hardCurrency = hardCurrencyService;
            _softCurrency = softCurrencyService;
            _showOnDemandLoadingPanelStrategy = showOnDemandLoadingPanelStrategy;

            OnShowSettingsPanel = new();
            OnLoadLobbySceneAsync = new();
            
            SoftCurrency = _softCurrency.Currency
                .Select(value => value.ToString().Length > 6 ? value.ToString()[..3] + "..." : value.ToString())
                .ToReadOnlyReactiveProperty();
            HardCurrency = _hardCurrency.Currency
                .Select(value => value.ToString().Length > 6 ? value.ToString()[..3] + "..." : value.ToString())
                .ToReadOnlyReactiveProperty();

            OnShowSettingsPanel.Subscribe(_ => _uIService.ShowPanel(_showOnDemandLoadingPanelStrategy, 
                Panels.Settings, "SettingsPanel", new SettingsPanelLifetimeScope()).Forget())
                .AddTo(_compositeDisposable);
            OnLoadLobbySceneAsync.Subscribe(_=>_sceneTransitionService.LoadSceneAsync(SceneIndex.Lobby))
                .AddTo(_compositeDisposable);
        }
    }
}
