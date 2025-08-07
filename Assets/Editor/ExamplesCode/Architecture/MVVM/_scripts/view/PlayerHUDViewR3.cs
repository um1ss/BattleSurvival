// Scripts/View/PlayerHUDViewR3.cs
using UnityEngine;
using TMPro; // Для TextMeshProUGUI
using R3; // Импортируем R3

/// <summary>
/// Представление: Отображает данные из ViewModel.
/// Подписывается на ReadOnlyReactiveProperty ViewModel.
/// </summary>
public class PlayerHUDViewR3 : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private PlayerHUDViewModelR3 _viewModel;
    // CompositeDisposable для управления подписками View.
    // Автоматически отписывает все подписки, когда MonoBehaviour уничтожается.
    private CompositeDisposable _viewDisposables = new CompositeDisposable();


    // Метод для инициализации View с ViewModel
    public void Initialize(PlayerHUDViewModelR3 viewModel)
    {
        // Перед повторной инициализацией, очищаем все предыдущие подписки View
        _viewDisposables.Dispose();
        _viewDisposables = new CompositeDisposable(); // Создаем новый, чистый Disposable

        _viewModel = viewModel;

        if (_viewModel != null)
        {
            // Подписываемся на DisplayHealth из ViewModel.
            // При каждом изменении DisplayHealth, вызывается lambda-функция для обновления healthText.
            // .AddTo(this) - это удобство R3 для MonoBehaviour, автоматически привязывает Dispose() к OnDestroy().
            _viewModel.DisplayHealth
                .Subscribe(text => healthText.text = text)
                .AddTo(this._viewDisposables); // Добавляем подписку в наш CompositeDisposable

            // Аналогично для счета
            _viewModel.DisplayScore
                .Subscribe(text => scoreText.text = text)
                .AddTo(this._viewDisposables); // Добавляем подписку в наш CompositeDisposable
        }
    }

    // OnDestroy вызывается, когда GameObject уничтожается.
    // Здесь мы очищаем все подписки, чтобы предотвратить утечки памяти.
    void OnDestroy()
    {
        // Важно: вызываем Dispose для _viewDisposables,
        // чтобы отписать все подписки, созданные в Initialize.
        _viewDisposables.Dispose();

        // Также вызываем Dispose для ViewModel, если она еще существует
        // (на случай, если GameInitializer не успеет это сделать или сцена закрывается)
        _viewModel?.Dispose();
    }
}