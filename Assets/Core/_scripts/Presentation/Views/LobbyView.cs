using DenisKim.Core.Application;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace DenisKim.Core.Presentation
{
    public sealed class LobbyView : BaseView
    {
        [SerializeField] Button _gameplayButton;
        [SerializeField] Button _mainMenuButton;

        [SerializeField] TextMeshProUGUI _softCurrencyText;
        [SerializeField] TextMeshProUGUI _hardCurrencyText;

        [Inject]
        readonly LobbyViewModel _lobbyViewModel;

        private void Start()
        {
            _lobbyViewModel.SoftCurrency
                .Subscribe(text => _softCurrencyText.text = text)
                .AddTo(_compositeDisposable);
            _lobbyViewModel.HardCurrency
                .Subscribe(text => _hardCurrencyText.text = text)
                .AddTo(_compositeDisposable);

            _mainMenuButton.OnClickAsObservable().Subscribe(_ =>
            {
                _lobbyViewModel.OnLoadMainMenuSceneAsync.Execute(_);
            }).AddTo(_compositeDisposable);
            _gameplayButton.OnClickAsObservable().Subscribe(_ =>
            {
                _lobbyViewModel.OnLoadGameplaySceneAsync.Execute(_);
            }).AddTo(_compositeDisposable);
        }
    }
}
