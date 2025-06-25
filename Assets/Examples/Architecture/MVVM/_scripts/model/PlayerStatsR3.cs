// Scripts/Model/PlayerStatsR3.cs
using R3; // Импортируем R3

/// <summary>
/// Модель: содержит данные игрока и базовую логику их изменения,
/// используя ReactiveProperty для уведомления об изменениях.
/// </summary>
public class PlayerStatsR3
{
    // ReactiveProperty автоматически уведомляет подписчиков при изменении .Value
    public ReactiveProperty<int> Health { get; }
    public ReactiveProperty<int> Score { get; }

    public PlayerStatsR3(int initialHealth, int initialScore)
    {
        Health = new ReactiveProperty<int>(initialHealth);
        Score = new ReactiveProperty<int>(initialScore);
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0) return;
        Health.Value = System.Math.Max(0, Health.Value - amount); // Обновляем значение через .Value
    }

    public void AddScore(int amount)
    {
        if (amount < 0) return;
        Score.Value += amount; // Обновляем значение через .Value
    }
}