using DenisKim.Core.Application;
using DenisKim.Core.Domain;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace DenisKim.Core.Presentation
{
    sealed public class MainMenuView : MonoBehaviour
    {
        [SerializeField] Button _lobbyButton;

        [Inject]
        readonly MainMenuViewModel _mainMenuViewModel;

        private CompositeDisposable _viewDisposables;

        void Awake()
        {
            _viewDisposables = new CompositeDisposable();
        }

        void OnEnable()
        {
            _lobbyButton.OnClickAsObservable()
                .Subscribe(_ => _mainMenuViewModel.TransitionToLobbyCommand.Execute((int)SceneIndex.Lobby))
                .AddTo(_viewDisposables);
        }

        void OnDisable()
        {
            _viewDisposables?.Dispose();
        }
    }
}