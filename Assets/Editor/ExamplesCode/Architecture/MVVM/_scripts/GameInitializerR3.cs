// Scripts/GameInitializerR3.cs
using UnityEngine;
using R3;
using System; // <--- Убедись, что это добавлено для TimeSpan

/// <summary>
/// Инициализатор: создает экземпляры Модели и ViewModel
/// и связывает их с Представлением.
/// </summary>
public class GameInitializerR3 : MonoBehaviour
{
    public PlayerHUDViewR3 playerHUDView; // Ссылка на наш UI View компонент

    private PlayerStatsR3 _playerStats;
    private PlayerHUDViewModelR3 _playerHUDViewModel;

    // Добавляем CompositeDisposable для управления подписками в этом MonoBehaviour
    private CompositeDisposable _disposables = new CompositeDisposable();

    void Awake()
    {
        // 1. Создаем Модель
        _playerStats = new PlayerStatsR3(100, 0); // Начальное здоровье: 100, Счет: 0

        // 2. Создаем ViewModel, передавая ей Модель
        _playerHUDViewModel = new PlayerHUDViewModelR3(_playerStats);

        // 3. Инициализируем View, передавая ей ViewModel
        if (playerHUDView != null)
        {
            playerHUDView.Initialize(_playerHUDViewModel);
        }
        else
        {
            Debug.LogError("Player HUD View not assigned to GameInitializer!");
        }

        // Для демонстрации: имитация изменения данных
        // Используем Observable.Interval из R3 для удобного таймера
        Observable.Interval(TimeSpan.FromSeconds(2))
            .Subscribe(_ => SimulateGameProgress())
            .AddTo(_disposables); // <--- Изменено: теперь подписка добавляется в наш _disposables
    }

    // --- Методы для имитации изменения данных в Модели ---
    private void SimulateGameProgress()
    {
        _playerStats.TakeDamage(UnityEngine.Random.Range(5, 15));
        _playerStats.AddScore(UnityEngine.Random.Range(10, 50));

        if (_playerStats.Health.Value <= 0) // Доступ к текущему значению через .Value
        {
            Debug.Log("Игрок мертв. Останавливаем симуляцию.");
            // <--- Изменено: Вызываем Dispose() для _disposables
            _disposables.Dispose(); // Отписываем все подписки, связанные с этим GameInitializerR3
        }
    }

    // Важно: вызываем Dispose() для _disposables, когда GameObject уничтожается,
    // чтобы гарантировать отписку от всех реактивных потоков.
    void OnDestroy()
    {
        _disposables.Dispose(); // Очищаем все подписки
        // ViewModel также нужно будет очистить
        _playerHUDViewModel?.Dispose();
    }
}