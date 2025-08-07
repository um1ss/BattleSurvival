// Scripts/ViewModel/PlayerHUDViewModelR3.cs
using R3; // Импортируем R3
using System;

/// <summary>
/// ViewModel: Подготавливает данные из Модели для Представления,
/// используя реактивные потоки R3.
/// </summary>
public class PlayerHUDViewModelR3 : IDisposable // Важно для управления подписками
{
    private PlayerStatsR3 _playerStats;
    // CompositeDisposable автоматически управляет отпиской всех добавленных подписок
    private CompositeDisposable _disposables = new CompositeDisposable();

    // ReadOnlyReactiveProperty - это "наблюдаемые" свойства для Представления.
    // Они представляют собой потоки строковых значений, готовых к отображению.
    public ReadOnlyReactiveProperty<string> DisplayHealth { get; }
    public ReadOnlyReactiveProperty<string> DisplayScore { get; }

    public PlayerHUDViewModelR3(PlayerStatsR3 playerStats)
    {
        _playerStats = playerStats;

        // Создаем наблюдаемое свойство DisplayHealth.
        // Каждый раз, когда Health в _playerStats меняется, этот поток выдает новое значение.
        // .Select() трансформирует int в string.
        // .ToReadOnlyReactiveProperty() создает ReadOnlyReactiveProperty, которое можно читать, но не изменять.
        // .AddTo(_disposables) гарантирует, что подписка будет автоматически отписана при Dispose().
        DisplayHealth = _playerStats.Health
            .Select(newHealth => $"Здоровье: {newHealth}")
            .ToReadOnlyReactiveProperty()
            .AddTo(_disposables); // Автоматическое управление подпиской

        // Аналогично для счета
        DisplayScore = _playerStats.Score
            .Select(newScore => $"Счет: {newScore}")
            .ToReadOnlyReactiveProperty()
            .AddTo(_disposables); // Автоматическое управление подпиской
    }

    /// <summary>
    /// Вызывается для очистки всех реактивных подписок.
    /// </summary>
    public void Dispose()
    {
        _disposables.Dispose(); // Отписываемся от всех подписок, добавленных в _disposables
        // ViewModel больше не будет получать уведомления от Модели
    }
}