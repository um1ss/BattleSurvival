using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Компонент MonoBehaviour, который слушает один или несколько параметризованных GameEvent.
/// Когда событие срабатывает, он вызывает UnityEvent с переданными данными.
/// </summary>
/// <typeparam name="T">Тип данных, передаваемых событием.</typeparam>
public class GameEventListener<T> : MonoBehaviour
{
    [Tooltip("Событие Scriptable Object, которое будет прослушиваться.")]
    public BaseGameEvent<T> Event;

    [Tooltip("Действия, которые будут вызваны при срабатывании события.")]
    public UnityEvent<T> Response;

    // При включении компонента подписываемся на событие
    private void OnEnable()
    {
        if (Event != null)
        {
            Event.RegisterListener(this);
        }
    }

    // При выключении компонента отписываемся от события
    private void OnDisable()
    {
        if (Event != null)
        {
            Event.UnregisterListener(this);
        }
    }

    /// <summary>
    /// Вызывается, когда Event Scriptable Object срабатывает с данными.
    /// </summary>
    /// <param name="value">Данные, переданные событием.</param>
    public void OnEventRaised(T value)
    {
        Response.Invoke(value); // Вызываем все привязанные UnityEvents с данными
    }
}