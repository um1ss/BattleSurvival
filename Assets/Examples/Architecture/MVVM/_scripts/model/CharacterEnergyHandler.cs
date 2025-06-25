using R3; // Библиотека для реактивного программирования (Reactive Extensions)
using UnityEngine; // Пространство имен Unity (добавил для Debug.Log)

namespace DenisKim.MVVM.Education.Model // Пространство имен для ваших Model-хендлеров
{
    public class CharacterEnergyHandler // Класс для управления энергией персонажа
    {
        public ReactiveProperty<int> Energy { get; } // Публичное реактивное свойство для хранения текущего значения энергии. Доступно для чтения извне, но изменяется внутри класса.

        public CharacterEnergyHandler() // Конструктор класса CharacterEnergyHandler
        {
            Energy = new ReactiveProperty<int>(0); // Инициализация энергии начальным значением 0
        }

        // Метод для добавления энергии. 'internal' означает, что метод доступен только в текущей сборке (Assembly).
        // Отличное переименование с 'AddEnergy' на 'AddEnergyCommand' для соответствия ViewModel,
        // и правильное использование параметра 'value'.
        internal void AddEnergyCommand(int value) 
        {
            Energy.Value += value; // Увеличиваем значение энергии на переданное 'value'
            Debug.Log($"EnergyHandler: Added {value} energy. Current: {Energy.Value}"); // Добавил лог для отслеживания изменений в консоли Unity
        }
    }
}