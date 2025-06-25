using Cysharp.Threading.Tasks; // Пространство имен для UniTask, библиотеки для асинхронного программирования в Unity
using System.Threading;       // Пространство имен для CancellationTokenSource и CancellationToken, используемых для управления асинхронными задачами
using R3; // Библиотека для реактивного программирования (Reactive Extensions)
using UnityEngine; // Основное пространство имен Unity для классов, таких как MonoBehaviour и Debug
using System; // Пространство имен для IDisposable и других базовых типов

// using VContainer.Unity; // <<< ЭТУ СТРОКУ МОЖНО УДАЛИТЬ, так как VContainer.Unity здесь не используется.

namespace DenisKim.MVVM.Education.Model // Пространство имен для ваших Model-хендлеров
{
    public class CharacterHealthHandler : IDisposable // Класс для управления здоровьем персонажа, реализует IDisposable для корректной очистки ресурсов
    {
        public ReactiveProperty<int> Health { get; } // Публичное реактивное свойство для хранения текущего здоровья. Доступно для чтения извне, но изменяется внутри класса.

        // Источник токена отмены для управления отменой асинхронных операций (например, процесса вычитания здоровья).
        private CancellationTokenSource cancellationTokenSource; 

        public CharacterHealthHandler() // Конструктор класса CharacterHealthHandler
        {
            Health = new ReactiveProperty<int>(100); // Инициализация здоровья начальным значением 100
            StartSubtracting(); // Автоматический запуск процесса вычитания здоровья при создании экземпляра хендлера
        }

        // Асинхронный метод UniTask, который выполняет периодическое вычитание здоровья
        private async UniTask SubtractValueEveryTwoSecondsAsync(CancellationToken token)
        {
            // Бесконечный цикл для повторения действия вычитания
            while (true)
            {
                // Проверяет, был ли запрошен токен отмены. Если да, выбрасывает OperationCanceledException и выходит из задачи.
                token.ThrowIfCancellationRequested(); 

                // Асинхронно ждет 2 секунды, не блокируя основной поток Unity.
                // 'ignoreTimeScale: false' означает, что задержка зависит от Time.timeScale.
                // 'cancellationToken: token' позволяет отменить ожидание, если токен будет отменен.
                await UniTask.WaitForSeconds(2f, ignoreTimeScale: false, cancellationToken: token); 

                // Повторная проверка токена отмены после задержки, на случай, если отмена произошла во время ожидания.
                token.ThrowIfCancellationRequested(); 

                Health.Value--; // Уменьшаем значение здоровья на 1
                
                // Выводим текущее значение здоровья в консоль Unity
                Debug.Log("Значение x после вычитания: " + Health.Value); 

                // Если здоровье достигло 0 или меньше, останавливаем процесс вычитания
                if (Health.Value <= 0)
                {
                    Debug.Log("Значение x достигло 0 или меньше. Остановка вычитания."); // Логируем остановку
                    StopSubtracting(); // Вызываем приватный метод для отмены токена и полной остановки процесса
                    break; // Выходим из бесконечного цикла while
                }
            }
        }

        // Метод для запуска процесса вычитания здоровья
        // Примечание: 'async void' используется для обработчиков событий и методов, которые не нужно 'await'ить.
        // Следует быть осторожным, так как необработанные исключения в 'async void' могут привести к падению приложения.
        private async void StartSubtracting() 
        {
            // Если предыдущий источник токена существует, отменяем его и создаем новый,
            // чтобы гарантировать, что старые асинхронные операции полностью остановлены.
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel(); // Отменяем текущую асинхронную операцию
                cancellationTokenSource.Dispose(); // Освобождаем ресурсы старого токена отмены
            }
            cancellationTokenSource = new CancellationTokenSource(); // Создаем новый источник токена отмены

            Debug.Log("Вычитание началось. Изначальное значение x: " + Health.Value); // Логируем начало процесса

            try
            {
                // Запускаем асинхронную задачу вычитания и ожидаем ее завершения (если не будет отменена).
                await SubtractValueEveryTwoSecondsAsync(cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                // Это исключение будет выброшено, если задача была отменена (нормальное поведение при запросе остановки).
                Debug.Log("Вычитание было отменено.");
            }
            catch (System.Exception ex)
            {
                // Ловим другие возможные исключения, чтобы избежать краша приложения
                Debug.LogError($"Произошла ошибка: {ex.Message}"); // Логируем ошибку в консоль Unity
            }
        }

        // Метод для остановки процесса вычитания здоровья
        private void StopSubtracting() // Метод сделан приватным, так как он вызывается только внутри класса или из Dispose
        {
            if (cancellationTokenSource != null) // Проверяем, существует ли источник токена
            {
                cancellationTokenSource.Cancel(); // Отменяем текущую асинхронную задачу
                cancellationTokenSource.Dispose(); // Освобождаем ресурсы, связанные с токеном отмены
                cancellationTokenSource = null;    // Обнуляем ссылку на источник токена, чтобы избежать повторной отмены/Dispose
                Debug.Log("Вычитание остановлено."); // Логируем остановку
            }
        }

        public void Dispose() // Метод интерфейса IDisposable, вызываемый VContainer при уничтожении синглтона для очистки ресурсов
        {
            StopSubtracting(); // При утилизации хендлера обязательно останавливаем процесс вычитания
        }
    }
}