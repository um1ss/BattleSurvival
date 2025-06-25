using UnityEngine;

/// <summary>
/// Scriptable Object для события, которое передает int значение.
/// </summary>
[CreateAssetMenu(menuName = "Game Events/Int Game Event")]
public class IntGameEvent : BaseGameEvent<int>
{
    // Этот класс наследует всю логику от GameEvent<int>
    // и служит только для создания конкретного типа актива через CreateAssetMenu.
}