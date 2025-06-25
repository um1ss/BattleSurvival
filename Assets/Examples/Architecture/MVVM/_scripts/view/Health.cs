using DenisKim.MVVM.Education.ViewModel; // Пространство имен вашей ViewModel
using R3; // Библиотека для реактивного программирования
using TMPro; // Пространство имен для TextMeshPro, продвинутого текстового компонента Unity
using UnityEngine; // Основное пространство имен Unity для классов, таких как MonoBehaviour
using VContainer; // Библиотека для внедрения зависимостей

namespace DenisKim.MVVM.Education.View // Пространство имен для ваших View-компонентов
{
    public class Health : MonoBehaviour // Класс Health, являющийся компонентом Unity, прикрепляемым к GameObject
    {
        [Inject] // Атрибут VContainer для автоматического внедрения зависимости
        CharacterHUDViewModel _characterHUDViewModel; // Внедряемая ViewModel, которая будет предоставлять данные и команды
        
        [SerializeField] // Атрибут Unity, который делает приватное поле видимым в инспекторе
        TextMeshProUGUI _textHealth; // Ссылка на компонент TextMeshPro, который будет отображать здоровье
        
        private CompositeDisposable _viewDisposables; // Приватный контейнер для всех подписок R3, связанных с этим View, для корректной очистки

        void Awake() // Метод Unity, вызывается при загрузке скрипта, до Start()
        {
            _viewDisposables = new CompositeDisposable(); // Инициализация контейнера для подписок, связанных с View
            
            _characterHUDViewModel.CurrentHealth // Доступ к реактивному свойству CurrentHealth в ViewModel
            .AsObservable() // Преобразует ReadOnlyReactiveProperty в наблюдаемый (Observable) поток
            .SubscribeToText(_textHealth, health => $"Здоровье: {health}") // Метод расширения R3: подписывает TextMeshPro на изменения потока, форматируя текст
            .AddTo(_viewDisposables); // Добавляет созданную подписку в CompositeDisposable для автоматической отписки при уничтожении View
        }

        void OnDestroy() // Метод Unity, вызывается, когда GameObject, к которому прикреплен этот скрипт, уничтожается
        {
            // Отлично! Вы убрали вызов _characterHUDViewModel.Dispose();.
            // ViewModel является синглтоном VContainer и управляется своим LifetimeScope.
            _viewDisposables.Dispose(); // Отписка всех подписок, добавленных в _viewDisposables, освобождая ресурсы и предотвращая утечки памяти
        }
    }
}