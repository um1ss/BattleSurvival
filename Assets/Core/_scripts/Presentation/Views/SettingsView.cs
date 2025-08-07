using DenisKim.Core.Application;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace DenisKim.Core.Presentation
{
    public sealed class SettingsView : BaseView
    {
        [SerializeField] Button _closeButton;
        //[SerializeField] Slider _sliderVolume;

        [Inject]
        readonly SettingsViewModel _settingsViewModel;

        private void Start()
        {
            _closeButton.OnClickAsObservable().Subscribe(_ =>
            {
                _settingsViewModel.OnClosePanel.Execute(_);
            }).AddTo(_compositeDisposable);

            //_sliderVolume.onValueChanged.AsObservable()
            //.Subscribe(value =>
            //{
            //    _settingsViewModel.SetVolume(value);
            //})
            //.AddTo(_disposables);
        }
    }
}