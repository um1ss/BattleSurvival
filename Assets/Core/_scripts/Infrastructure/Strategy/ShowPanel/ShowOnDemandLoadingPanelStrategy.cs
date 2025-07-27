using DenisKim.Core.Domain;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Infrastructure
{
    public sealed class ShowOnDemandLoadingPanelStrategy : IShowPanelStrategy
    {
        public void HidePanel(Panels panel,
            Dictionary<Panels, (GameObject instance, AsyncOperationHandle<GameObject> handle,
                LifetimeScope lifetimeScope)> loadedPanels,
            ref Panels currentActivePanel)
        {
            if (currentActivePanel != Panels.None)
            {
                Addressables.Release(loadedPanels[currentActivePanel].handle);
                loadedPanels[currentActivePanel].lifetimeScope.Dispose();
                Object.Destroy(loadedPanels[currentActivePanel].instance);
                loadedPanels.Remove(currentActivePanel);
                currentActivePanel = Panels.None;
            }
            currentActivePanel = panel;
            loadedPanels[currentActivePanel].instance.SetActive(true);
        }
    }
}
