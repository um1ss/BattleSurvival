using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DenisKim.Core.Application;
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

        private void Start()
        {
            if (_mainMenuViewModel != null)
                return;
            else
                Debug.Log("Main Menu View Model == null");
        }
    }

}
