using DenisKim.Core.Application;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace DenisKim.Core.Presentation
{
    sealed public class MainMenuView : AbstractView
    {
        #region UI Panel Components
        [SerializeField] Button _settingsButton;
        [SerializeField] Button _shopButton;
        [SerializeField] Button _tasksButton;
        [SerializeField] Button _collectionButton;
        [SerializeField] Button _lobbyButton;
        [SerializeField] Button _tuningButton;
        [SerializeField] Button _temporaryOffersButton;
        [SerializeField] Button _machineImprovementButton;
        #endregion

        #region Dependency on DI container
        [Inject]
        readonly MainMenuViewModel _mainMenuViewModel;
        #endregion

        private void OnEnable()
        {
            _lobbyButton.OnClickAsObservable().Subscribe(async _ => await _mainMenuViewModel.TransitionScene(2));
        }

        private void Start()
        {

        }

        private void OnDisable()
        {
        }
    }

}
