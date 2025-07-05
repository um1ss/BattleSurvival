using System; // Необходим для базовых типов, таких как IDisposable
using R3; // Библиотека для реактивного программирования (Reactive Extensions)
using VContainer; // Библиотека для внедрения зависимостей (Dependency Injection)

namespace DenisKim.MVVM.Education // Пространство имен для ваших ViewModel
{
    public class CharacterHUDViewModel : IDisposable // Класс ViewModel, реализующий IDisposable для корректной очистки ресурсов
    {
        readonly CharacterHealthHandler _healthHandler; // Приватная ссылка на хендлер здоровья (инъекция через DI)
        readonly CharacterEnergyHandler _energyHandler; // Приватная ссылка на хендлер энергии (инъекция через DI)
        
        // Публичное ReadOnlyReactiveProperty для доступа к текущему здоровью из хендлера (Модели)M
        public ReadOnlyReactiveProperty<int> CurrentHealth => _healthHandler.Health; 
        
        // Публичное ReadOnlyReactiveProperty для доступа к текущей энергии из хендлера (Модели)
        public ReadOnlyReactiveProperty<int> CurrentEnergy => _energyHandler.Energy; 
        
        // Публичная команда для добавления энергии. Использует R3.Unit, так как не принимает параметров.
        // Отличное переименование с 'Calculate' на 'AddEnergyCommand'!
        public ReactiveCommand<Unit> AddEnergyCommand { get; } 
        
        private CompositeDisposable _disposables; // Приватный контейнер для всех подписок R3, управляемых этой ViewModel

        [Inject] // Атрибут VContainer для автоматического внедрения зависимостей в конструктор
        public CharacterHUDViewModel(CharacterHealthHandler characterHealthHandler, CharacterEnergyHandler energyHandler)
        {
            _disposables = new CompositeDisposable(); // Инициализация CompositeDisposable В НАЧАЛЕ конструктора. Отлично!
                                                      // Это гарантирует, что _disposables готов до добавления в него подписок.
            
            _healthHandler = characterHealthHandler; // Присваивание внедренной зависимости для хендлера здоровья
            _energyHandler = energyHandler; // Присваивание внедренной зависимости для хендлера энергии
            
            AddEnergyCommand = new ReactiveCommand<Unit>(); // Инициализация новой реактивной команды без источника 'canExecute'
                                                            // Если команда всегда должна быть доступна, можно было бы
                                                            // использовать 'new ReactiveCommand<Unit>(Observable.Return(true))'.
                                                            // Для команд, которые всегда активны, это не строго обязательно,
                                                            // но делает намерение явным.
            
            AddEnergyCommand // Подписка на выполнение команды AddEnergyCommand
            .Subscribe(_ => // Лямбда-выражение, которое будет выполняться при вызове команды. '_' указывает, что параметр (Unit) не используется.
            {
                // Вызов метода AddEnergyCommand в хендлере энергии (_energyHandler).
                // Убедитесь, что 'AddEnergyCommand' в CharacterEnergyHandler является методом, а не свойством,
                // и принимает 'int value'.
                _energyHandler.AddEnergyCommand(); 
            }).AddTo(_disposables); // Добавление подписки на команду в CompositeDisposable для автоматической отписки при Dispose
        }

        public void Dispose() // Метод, вызываемый VContainer при уничтожении синглтона для корректной очистки ресурсов ViewModel
        {
            _disposables.Dispose(); // Освобождение всех ресурсов, связанных с подписками, добавленными в _disposables
        }
    }
}