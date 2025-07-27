using DenisKim.Core.Application;
using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace DenisKim.Core.Presentation
{
    public sealed class SettingsView : MonoBehaviour
    {
        [SerializeField] Button _closeButton;

        [Inject]
        readonly SettingsViewModel _settingsViewModel;
        [Inject]
        readonly ShowOnDemandLoadingPanelStrategy _showOnDemandLoadingPanelStrategy;

        CompositeDisposable _disposables;

        void Awake()
        {
            _disposables = new CompositeDisposable();
        }

        private void Start()
        {
            _closeButton.OnClickAsObservable().Subscribe(_ =>
            {
                _settingsViewModel.HidePanel();
            }).AddTo(_disposables);
        }

        private void OnDestroy()
        {
            _disposables?.Dispose();
        }
    }
}