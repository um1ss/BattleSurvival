using Cysharp.Threading.Tasks;
using DenisKim.Core.Application;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace DenisKim.Core.Presentation
{
    sealed public class MainMenuView : MonoBehaviour
    {
        [SerializeField] Button _lobbyButton;
        [SerializeField] Button _settingsButton;

        [Inject]
        readonly MainMenuViewModel _mainMenuViewModel;

        [Inject]
        readonly ShowOnDemandLoadingPanelStrategy _showOnDemandLoadingPanelStrategy;

        CompositeDisposable _disposables;

        void Awake()
        {
            _disposables = new CompositeDisposable();
        }

        private void Start()
        {
            _lobbyButton.OnClickAsObservable().Subscribe(_ =>
            {
                _mainMenuViewModel.LoadSceneAsync(SceneIndex.Lobby);
            }).AddTo(_disposables);
            _settingsButton.OnClickAsObservable().Subscribe(async _=>
            {
                await _mainMenuViewModel.ShowPanel(_showOnDemandLoadingPanelStrategy, Panels.Settings,
                    "SettingsPanel", new SettingsPanelLifetimeScope());
            }).AddTo(_disposables);
        }

        void OnDestroy()
        {
            _disposables?.Dispose();
        }
    }
}