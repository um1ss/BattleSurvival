using DenisKim.MVVM.Education.ViewModel; // Пространство имен вашей ViewModel
using R3; // Библиотека для реактивного программирования
using TMPro; // Пространство имен для TextMeshPro, продвинутого текстового компонента Unity
using UnityEngine; // Основное пространство имен Unity
using UnityEngine.UI; // Пространство имен для стандартных UI-компонентов Unity (например, Button)
using VContainer; // Библиотека для внедрения зависимостей

namespace DenisKim.MVVM.Education.View // Пространство имен для ваших View-компонентов
{
    public class Energy : MonoBehaviour // Класс Energy, являющийся компонентом Unity, прикрепляемым к GameObject
    {
        [Inject] // Атрибут VContainer для автоматического внедрения зависимости
        CharacterHUDViewModel _characterHUDViewModel; // Внедряемая ViewModel, которая будет предоставлять данные и команды
        
        [SerializeField] // Атрибут Unity, который делает приватное поле видимым в инспекторе
        Button _buttonAddEnergy; // Ссылка на компонент Button в UI, который будет вызывать команду добавления энергии
        
        [SerializeField] // Атрибут Unity для сериализации приватного поля
        TextMeshProUGUI _textEnergy; // Ссылка на компонент TextMeshPro, который будет отображать текущее значение энергии

        private CompositeDisposable _viewDisposables; // Приватный контейнер для всех подписок R3, связанных с этим View, для корректной очистки

        void Awake() // Метод Unity, вызывается при загрузке скрипта, до Start()
        {
            _viewDisposables = new CompositeDisposable(); // Инициализация контейнера для подписок, связанных с View
            
            _buttonAddEnergy.OnClickAsObservable() // Метод расширения R3: преобразует события кликов по кнопке в наблюдаемый (Observable) поток
            .Subscribe(_characterHUDViewModel.AddEnergyCommand.Execute) // Подписывается на поток кликов, вызывая метод Execute у команды AddEnergyCommand в ViewModel
            .AddTo(_viewDisposables); // Добавляет созданную подписку в CompositeDisposable для автоматической отписки при уничтожении View

            _characterHUDViewModel.CurrentEnergy // Доступ к реактивному свойству CurrentEnergy в ViewModel
            .AsObservable() // Преобразует ReadOnlyReactiveProperty в наблюдаемый поток
            .SubscribeToText(_textEnergy, energy => $"Енергия: {energy}") // Метод расширения R3: подписывает TextMeshPro на изменения потока, форматируя текст
            .AddTo(_viewDisposables); // Добавляет созданную подписку в CompositeDisposable для автоматической отписки при уничтожении View
        }

        void OnDestroy() // Метод Unity, вызывается, когда GameObject, к которому прикреплен этот скрипт, уничтожается
        {
            // Отлично! Вы убрали вызов _characterHUDViewModel?.Dispose();.
            // ViewModel является синглтоном VContainer и управляется своим LifetimeScope.
            _viewDisposables.Dispose(); // Отписка всех подписок, добавленных в _viewDisposables, освобождая ресурсы и предотвращая утечки памяти
        }
    }
}