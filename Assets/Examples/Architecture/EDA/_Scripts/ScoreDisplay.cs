using UnityEngine;
using TMPro; // Убедись, что у тебя импортирован TextMeshPro (Window -> TextMeshPro -> Import TMP Essential Resources)

/// <summary>
/// Отображает текущий счет, реагируя на событие подбора предмета.
/// </summary>
public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Ссылка на текстовый компонент UI
    private int currentScore = 0;

    void Start()
    {
        UpdateScoreDisplay();
    }

    /// <summary>
    /// Этот метод будет вызван, когда сработает событие IntGameEvent.
    /// </summary>
    /// <param name="itemValue">Ценность подобранного предмета.</param>
    public void AddScore(int itemValue)
    {
        currentScore += itemValue;
        UpdateScoreDisplay();
        Debug.Log($"Счет обновлен: {currentScore}");
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Счет: {currentScore}";
        }
    }
}