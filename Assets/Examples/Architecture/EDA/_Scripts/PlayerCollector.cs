using UnityEngine;

/// <summary>
/// Имитирует игрока, который подбирает объекты и вызывает событие.
/// </summary>
public class PlayerCollector : MonoBehaviour
{
    [Tooltip("Событие, которое будет вызвано при подборе объекта.")]
    public IntGameEvent onItemCollectedEvent; // Ссылка на наш Scriptable Object события

    public void CollectItem(int value)
    {
        Debug.Log($"Игрок подобрал предмет! Ценность: {value}");

        // Вызываем событие, передавая ценность предмета
        if (onItemCollectedEvent != null)
        {
            onItemCollectedEvent.Raise(value);
        }
    }

    // Пример вызова события (можно привязать к кнопке или к триггеру)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Имитируем подбор предмета с рандомной ценностью
            CollectItem(Random.Range(1, 10));
        }
    }
}