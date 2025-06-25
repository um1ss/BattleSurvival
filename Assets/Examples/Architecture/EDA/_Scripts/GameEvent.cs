using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

/// <summary>
/// Базовый Scriptable Object для параметризованных событий.
/// Он управляет списком слушателей и позволяет вызывать событие с данными.
/// </summary>
/// <typeparam name="T">Тип данных, передаваемых событием.</typeparam>
public abstract class BaseGameEvent<T> : ScriptableObject, IGameEvent<T>
{
    private readonly List<GameEventListener<T>> eventListeners = new List<GameEventListener<T>>();

    /// <summary>
    /// Вызывает это событие, уведомляя всех зарегистрированных слушателей и передавая данные.
    /// </summary>
    /// <param name="value">Данные для передачи.</param>
    public void Raise(T value)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(value);
        }
    }

    /// <summary>
    /// Регистрирует слушателя на это событие.
    /// </summary>
    /// <param name="listener">Слушатель для регистрации.</param>
    public void RegisterListener(GameEventListener<T> listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }

    /// <summary>
    /// Отменяет регистрацию слушателя с этого события.
    /// </summary>
    /// <param name="listener">Слушатель для отмены регистрации.</param>
    public void UnregisterListener(GameEventListener<T> listener)
    {
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}