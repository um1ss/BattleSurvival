using Cysharp.Threading.Tasks; // Для UniTask
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UnityEngine.AddressableAssets; // Пространство имен для Addressables
using UnityEngine.ResourceManagement.AsyncOperations; // Для AsyncOperationHandle

namespace DenisKim.MVVM.Education
{
    public class UIManager : IInitializable // IInitializable для выполнения действий после внедрения зависимостей
    {
        private readonly LifetimeScope _parentLifetimeScope; // LifetimeScope, в котором зарегистрирован UIManager, для создания дочерних скоупов

        // Словарь для хранения загруженных UI-панелей и их AsyncOperationHandle для корректной выгрузки Addressables
        private Dictionary<string, (GameObject instance, AsyncOperationHandle<GameObject> handle)> _loadedUIPanels = 
            new Dictionary<string, (GameObject, AsyncOperationHandle<GameObject>)>();

        // Для примера, можно хранить ссылку на текущую активную панель
        private GameObject _currentActivePanel = null;

        [Inject]
        public UIManager(LifetimeScope parentLifetimeScope) // Инжектируем родительский LifetimeScope
        {
            _parentLifetimeScope = parentLifetimeScope;
        }

        public void Initialize()
        {
            Debug.Log("UIManager инициализирован.");
            // Здесь можно инициализировать Persistent UI, если он также загружается динамически.
        }

        /// <summary>
        /// Показывает UI-панель, загружая ее через Addressables.
        /// </summary>
        /// <param name="panelAddress">Адрес Addressable UI-панели.</param>
        /// <returns>UniTask, который завершится, когда панель будет показана.</returns>
        public async UniTask ShowPanelAsync(string panelAddress)
        {
            if (_loadedUIPanels.ContainsKey(panelAddress))
            {
                // Если панель уже загружена и присутствует, просто активируем ее
                _loadedUIPanels[panelAddress].instance.SetActive(true);
                _currentActivePanel = _loadedUIPanels[panelAddress].instance;
                Debug.Log($"Панель '{panelAddress}' активирована.");
                return;
            }

            // Асинхронная загрузка префаба через Addressables
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(panelAddress);
            await handle.ToUniTask(); // Ждем завершения загрузки

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"Не удалось загрузить UI-панель '{panelAddress}' через Addressables. Статус: {handle.Status}");
                // Важно освободить хендл, если загрузка не удалась, чтобы избежать утечек памяти Addressables
                Addressables.Release(handle);
                return;
            }

            GameObject panelPrefab = handle.Result;
            if (panelPrefab == null)
            {
                Debug.LogError($"Загруженный префаб для адреса '{panelAddress}' оказался null.");
                Addressables.Release(handle);
                return;
            }

            // Создаем дочерний LifetimeScope для UI-панели.
            // Это позволяет ViewModel и другим зависимостям панели иметь свой собственный жизненный цикл.
            using (var childScope = _parentLifetimeScope.CreateChild())
            {
                // !!! ИСПРАВЛЕНИЕ ОШИБКИ 1: Вызываем Instantiate у контейнера дочернего скоупа
                GameObject panelInstance = childScope.Container.Instantiate(panelPrefab);

                // Находим Canvas в сцене и устанавливаем его родителем для новой панели.
                // Убедитесь, что у вас есть Canvas в сцене или создайте его.
                Transform canvasTransform = GameObject.FindObjectOfType<Canvas>()?.transform;
                if (canvasTransform != null)
                {
                    panelInstance.transform.SetParent(canvasTransform, false);
                }
                else
                {
                    Debug.LogWarning("Canvas не найден в сцене. UI-панель будет инстанциирована в корне.");
                }

                _loadedUIPanels[panelAddress] = (panelInstance, handle);
                _currentActivePanel = panelInstance;

                Debug.Log($"Панель '{panelAddress}' загружена и показана.");
            }
        }

        /// <summary>
        /// Скрывает UI-панель по адресу Addressable.
        /// </summary>
        /// <param name="panelAddress">Адрес Addressable UI-панели.</param>
        public void HidePanel(string panelAddress)
        {
            // !!! ИСПРАВЛЕНИЕ ОШИБКИ 2: Исправлена опечатка _loadedUIPels на _loadedUIPanels
            if (_loadedUIPanels.TryGetValue(panelAddress, out var panelData))
            {
                panelData.instance.SetActive(false);
                if (_currentActivePanel == panelData.instance)
                {
                    _currentActivePanel = null;
                }
                Debug.Log($"Панель '{panelAddress}' скрыта.");
            }
            else
            {
                Debug.LogWarning($"Панель '{panelAddress}' не найдена или не загружена.");
            }
        }

        /// <summary>
        /// Полностью уничтожает UI-панель и освобождает ее ресурсы Addressables.
        /// </summary>
        /// <param name="panelAddress">Адрес Addressable UI-панели.</param>
        public void DestroyPanel(string panelAddress)
        {
            if (_loadedUIPanels.TryGetValue(panelAddress, out var panelData))
            {
                if (_currentActivePanel == panelData.instance)
                {
                    _currentActivePanel = null;
                }
                _loadedUIPanels.Remove(panelAddress);

                // Уничтожаем GameObject инстанциированной панели.
                // VContainer автоматически Dispose'ит зависимости дочернего скоупа при уничтожении GameObject,
                // если ViewModel была зарегистрирована в дочернем скоупе, созданном через childScope.Container.Instantiate.
                GameObject.Destroy(panelData.instance);

                // Освобождаем Addressable ресурс, используя AsyncOperationHandle, который мы сохранили.
                Addressables.Release(panelData.handle);
                Debug.Log($"Панель '{panelAddress}' уничтожена и ее ресурсы освобождены.");
            }
            else
            {
                Debug.LogWarning($"Панель '{panelAddress}' не найдена для уничтожения.");
            }
        }

        /// <summary>
        /// Скрывает текущую активную панель (если есть).
        /// </summary>
        public void HideCurrentPanel()
        {
            if (_currentActivePanel != null)
            {
                _currentActivePanel.SetActive(false);
                _currentActivePanel = null;
                Debug.Log("Текущая активная панель скрыта.");
            }
        }
    }
}