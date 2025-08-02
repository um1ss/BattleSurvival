using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;
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

        readonly ICanvasService _canvasService;

        readonly Dictionary<Panels, (GameObject instance,
            AsyncOperationHandle<GameObject> handle, LifetimeScope lifetimeScope)> _loadedUIPanels;

        Panels _currentActivePersistentPanel;
        Panels _currentActiveOnDemandLoadingPanel;

        [Inject]
        public UIService(RootLifetimeScope rootLifetimeScope,
            ICanvasService canvasService)
        {
            _rootLifetimeScope = rootLifetimeScope;
            _canvasService = canvasService;
            _loadedUIPanels = new Dictionary<Panels,
                (GameObject, AsyncOperationHandle<GameObject>, LifetimeScope lifetimeScope)>();
        }

        async UniTask AddPanelDictionary(Panels panel, string address, IInstaller installer)
        {
            var childLifetimeScope = _rootLifetimeScope.CreateChild(installer);
            var handle = Addressables.LoadAssetAsync<GameObject>(address);
            var instance = childLifetimeScope.Container.Instantiate(await handle.ToUniTask(),
                _canvasService.GetTransform, false);
            instance.SetActive(false);
            _loadedUIPanels.Add(panel,
                (instance, handle, childLifetimeScope));
        }

        public async UniTask ShowPanel(IShowPanelStrategy showPanelStrategy, Panels panel,
            string address,
            IInstaller installer)
        {
            if (!_loadedUIPanels.ContainsKey(panel))
                await AddPanelDictionary(panel, address, installer);
            if (showPanelStrategy is ShowPersistentPanelStrategy)
                showPanelStrategy.UnloadPanel(panel, _loadedUIPanels, ref _currentActivePersistentPanel);
            else
                showPanelStrategy.UnloadPanel(panel, _loadedUIPanels, ref _currentActiveOnDemandLoadingPanel);
        }

        public void HidePanel()
        {
            Addressables.Release(_loadedUIPanels[_currentActiveOnDemandLoadingPanel].handle);
            _loadedUIPanels[_currentActiveOnDemandLoadingPanel].lifetimeScope.Dispose();
            Object.Destroy(_loadedUIPanels[_currentActiveOnDemandLoadingPanel].instance);
            _loadedUIPanels.Remove(_currentActiveOnDemandLoadingPanel);
            _currentActiveOnDemandLoadingPanel = Panels.None;
        }
    }
}
