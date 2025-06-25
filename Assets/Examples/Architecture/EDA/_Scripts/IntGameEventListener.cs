using UnityEngine;

/// <summary>
/// Конкретный GameEventListener для прослушивания событий IntGameEvent.
/// </summary>
public class IntGameEventListener : GameEventListener<int>
{
    // Этот класс наследует всю логику от GameEventListener<int>
    // и служит только для того, чтобы сделать его конкретным MonoBehaviour,
    // который можно прикрепить к GameObject.
}