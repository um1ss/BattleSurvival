using DenisKim.Core.Domain;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Infrastructure
{
    public interface IShowPanelStrategy
    {
        void UnloadPanel(Panels panel,
            Dictionary<Panels, (GameObject instance,
            AsyncOperationHandle<GameObject> handle, LifetimeScope lifetimeScope)> loadedPanels,
            ref Panels currentActivePanel);
    }
}
