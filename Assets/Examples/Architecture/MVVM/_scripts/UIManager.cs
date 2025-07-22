using Cysharp.Threading.Tasks; // ��� UniTask
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UnityEngine.AddressableAssets; // ������������ ���� ��� Addressables
using UnityEngine.ResourceManagement.AsyncOperations; // ��� AsyncOperationHandle

namespace DenisKim.MVVM.Education
{
    public class UIManager : IInitializable // IInitializable ��� ���������� �������� ����� ��������� ������������
    {
        private readonly LifetimeScope _parentLifetimeScope; // LifetimeScope, � ������� ��������������� UIManager, ��� �������� �������� �������

        // ������� ��� �������� ����������� UI-������� � �� AsyncOperationHandle ��� ���������� �������� Addressables
        private Dictionary<string, (GameObject instance, AsyncOperationHandle<GameObject> handle)> _loadedUIPanels = 
            new Dictionary<string, (GameObject, AsyncOperationHandle<GameObject>)>();

        // ��� �������, ����� ������� ������ �� ������� �������� ������
        private GameObject _currentActivePanel = null;

        [Inject]
        public UIManager(LifetimeScope parentLifetimeScope) // ����������� ������������ LifetimeScope
        {
            _parentLifetimeScope = parentLifetimeScope;
        }

        public void Initialize()
        {
            Debug.Log("UIManager ���������������.");
            // ����� ����� ���������������� Persistent UI, ���� �� ����� ����������� �����������.
        }

        /// <summary>
        /// ���������� UI-������, �������� �� ����� Addressables.
        /// </summary>
        /// <param name="panelAddress">����� Addressable UI-������.</param>
        /// <returns>UniTask, ������� ����������, ����� ������ ����� ��������.</returns>
        public async UniTask ShowPanelAsync(string panelAddress)
        {
            if (_loadedUIPanels.ContainsKey(panelAddress))
            {
                // ���� ������ ��� ��������� � ������������, ������ ���������� ��
                _loadedUIPanels[panelAddress].instance.SetActive(true);
                _currentActivePanel = _loadedUIPanels[panelAddress].instance;
                Debug.Log($"������ '{panelAddress}' ������������.");
                return;
            }

            // ����������� �������� ������� ����� Addressables
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(panelAddress);
            await handle.ToUniTask(); // ���� ���������� ��������

            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"�� ������� ��������� UI-������ '{panelAddress}' ����� Addressables. ������: {handle.Status}");
                // ����� ���������� �����, ���� �������� �� �������, ����� �������� ������ ������ Addressables
                Addressables.Release(handle);
                return;
            }

            GameObject panelPrefab = handle.Result;
            if (panelPrefab == null)
            {
                Debug.LogError($"����������� ������ ��� ������ '{panelAddress}' �������� null.");
                Addressables.Release(handle);
                return;
            }

            // ������� �������� LifetimeScope ��� UI-������.
            // ��� ��������� ViewModel � ������ ������������ ������ ����� ���� ����������� ��������� ����.
            using (var childScope = _parentLifetimeScope.CreateChild())
            {
                // !!! ����������� ������ 1: �������� Instantiate � ���������� ��������� ������
                GameObject panelInstance = childScope.Container.Instantiate(panelPrefab);

                // ������� Canvas � ����� � ������������� ��� ��������� ��� ����� ������.
                // ���������, ��� � ��� ���� Canvas � ����� ��� �������� ���.
                Transform canvasTransform = GameObject.FindObjectOfType<Canvas>()?.transform;
                if (canvasTransform != null)
                {
                    panelInstance.transform.SetParent(canvasTransform, false);
                }
                else
                {
                    Debug.LogWarning("Canvas �� ������ � �����. UI-������ ����� ��������������� � �����.");
                }

                _loadedUIPanels[panelAddress] = (panelInstance, handle);
                _currentActivePanel = panelInstance;

                Debug.Log($"������ '{panelAddress}' ��������� � ��������.");
            }
        }

        /// <summary>
        /// �������� UI-������ �� ������ Addressable.
        /// </summary>
        /// <param name="panelAddress">����� Addressable UI-������.</param>
        public void HidePanel(string panelAddress)
        {
            // !!! ����������� ������ 2: ���������� �������� _loadedUIPels �� _loadedUIPanels
            if (_loadedUIPanels.TryGetValue(panelAddress, out var panelData))
            {
                panelData.instance.SetActive(false);
                if (_currentActivePanel == panelData.instance)
                {
                    _currentActivePanel = null;
                }
                Debug.Log($"������ '{panelAddress}' ������.");
            }
            else
            {
                Debug.LogWarning($"������ '{panelAddress}' �� ������� ��� �� ���������.");
            }
        }

        /// <summary>
        /// ��������� ���������� UI-������ � ����������� �� ������� Addressables.
        /// </summary>
        /// <param name="panelAddress">����� Addressable UI-������.</param>
        public void DestroyPanel(string panelAddress)
        {
            if (_loadedUIPanels.TryGetValue(panelAddress, out var panelData))
            {
                if (_currentActivePanel == panelData.instance)
                {
                    _currentActivePanel = null;
                }
                _loadedUIPanels.Remove(panelAddress);

                // ���������� GameObject ����������������� ������.
                // VContainer ������������� Dispose'�� ����������� ��������� ������ ��� ����������� GameObject,
                // ���� ViewModel ���� ���������������� � �������� ������, ��������� ����� childScope.Container.Instantiate.
                GameObject.Destroy(panelData.instance);

                // ����������� Addressable ������, ��������� AsyncOperationHandle, ������� �� ���������.
                Addressables.Release(panelData.handle);
                Debug.Log($"������ '{panelAddress}' ���������� � �� ������� �����������.");
            }
            else
            {
                Debug.LogWarning($"������ '{panelAddress}' �� ������� ��� �����������.");
            }
        }

        /// <summary>
        /// �������� ������� �������� ������ (���� ����).
        /// </summary>
        public void HideCurrentPanel()
        {
            if (_currentActivePanel != null)
            {
                _currentActivePanel.SetActive(false);
                _currentActivePanel = null;
                Debug.Log("������� �������� ������ ������.");
            }
        }
    }
}