using Cysharp.Threading.Tasks;
using DenisKim.Core.LifetimScope;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Domain
{
    public sealed class UIService : IUIService
    {
        readonly RootLifetimeScope _rootLifetimeScope;

        readonly Canvas _canvas;
        readonly Dictionary<PanelsEnum, (GameObject instance,
            AsyncOperationHandle<GameObject> handle, LifetimeScope lifetimeScope)> _loadedUIPanels;

        PanelsEnum _currentActivePersistentPanel;
        PanelsEnum _currentActiveOnDemandLoadingPanel;

        [Inject]
        public UIService(RootLifetimeScope rootLifetimeScope,
            Canvas canvas)
        {
            _rootLifetimeScope = rootLifetimeScope;
            _canvas = canvas;
            _loadedUIPanels = new Dictionary<PanelsEnum,
                (GameObject, AsyncOperationHandle<GameObject>, LifetimeScope lifetimeScope)>();
        }

        async UniTask AddPanelDictionary(PanelsEnum panel, string address, IInstaller installer)
        {
            var childLifetimeScope = _rootLifetimeScope.CreateChild(installer);
            var handle = Addressables.LoadAssetAsync<GameObject>(address);
            var instance = childLifetimeScope.Container.Instantiate(await handle.ToUniTask(),
                _canvas.transform, false);
            instance.SetActive(false);
            _loadedUIPanels.Add(panel,
                (instance, handle, childLifetimeScope));
        }

        public async UniTask ShowPersistentPanel(PanelsEnum panel,
            string address,
            IInstaller installer)
        {
            if (!_loadedUIPanels.ContainsKey(panel))
            {
                await AddPanelDictionary(panel, address, installer);
            }
            if (_currentActivePersistentPanel != PanelsEnum.None)
            {
                _loadedUIPanels[_currentActivePersistentPanel].instance.SetActive(false);
            }
            _currentActivePersistentPanel = panel;
            _loadedUIPanels[_currentActivePersistentPanel].instance.SetActive(true);
        }

        public async UniTask ShowOnDemandLoadingPanel(PanelsEnum panel,
            string address,
            IInstaller installer)
        {
            if (!_loadedUIPanels.ContainsKey(panel))
            {
                await AddPanelDictionary(panel, address, installer);
            }
            if (_currentActiveOnDemandLoadingPanel != PanelsEnum.None)
            {
                _loadedUIPanels[_currentActiveOnDemandLoadingPanel].instance.SetActive(false);
            }
            _currentActiveOnDemandLoadingPanel = panel;
            _loadedUIPanels[_currentActiveOnDemandLoadingPanel].instance.SetActive(true);
        }
    }
}
