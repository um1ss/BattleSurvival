using DenisKim.Core.Domain;
using R3;

namespace DenisKim.Core.Application
{
    public sealed class LobbyViewModel : BaseViewModel
    {
        readonly ISceneTransitionService _sceneTransitionService;
        readonly ICurrency _hardCurrency;
        readonly ICurrency _softCurrency;

        public ReadOnlyReactiveProperty<string> HardCurrency { get; }
        public ReadOnlyReactiveProperty<string> SoftCurrency { get; }

        public ReactiveCommand<Unit> OnLoadGameplaySceneAsync { get; }
        public ReactiveCommand<Unit> OnLoadMainMenuSceneAsync { get; }

        public LobbyViewModel(ISceneTransitionService sceneTransitionService,
            HardCurrencyService hardCurrencyService,
            SoftCurrencyService softCurrencyService) : base()
        {
            _sceneTransitionService = sceneTransitionService;
            _hardCurrency = hardCurrencyService;
            _softCurrency = softCurrencyService;

            OnLoadGameplaySceneAsync = new();
            OnLoadMainMenuSceneAsync = new();

            SoftCurrency = _softCurrency.Currency
                .Select(value => value.ToString().Length > 6 ? value.ToString()[..3] + "..." :
                value.ToString())
                .ToReadOnlyReactiveProperty();
            HardCurrency = _hardCurrency.Currency
                .Select(value => value.ToString().Length > 6 ? value.ToString()[..3] + "..." :
                value.ToString())
                .ToReadOnlyReactiveProperty();

            OnLoadGameplaySceneAsync.Subscribe(_ => _sceneTransitionService
                .LoadSceneAsync(SceneIndex.Gameplay)).AddTo(_compositeDisposable);
            OnLoadMainMenuSceneAsync.Subscribe(_ => _sceneTransitionService.
                LoadSceneAsync(SceneIndex.MainMenu)).AddTo(_compositeDisposable);
        }
    }
}
