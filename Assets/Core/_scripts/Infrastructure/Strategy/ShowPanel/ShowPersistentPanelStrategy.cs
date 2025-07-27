using DenisKim.Core.Domain;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Infrastructure
{
    public sealed class ShowPersistentPanelStrategy : IShowPanelStrategy
    {
        public void UnloadPanel(Panels panel,
            Dictionary<Panels, (GameObject instance, AsyncOperationHandle<GameObject> handle,
                LifetimeScope lifetimeScope)> loadedPanels,
            ref Panels currentActivePanel)
        {
            if (currentActivePanel != Panels.None)
                loadedPanels[currentActivePanel].instance.SetActive(false);
            currentActivePanel = panel;
            loadedPanels[currentActivePanel].instance.SetActive(true);
        }
    }
}
