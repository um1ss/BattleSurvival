using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer.Unity;

namespace DenisKim.Core.Infrastructure
{
    public interface IShowPanelStrategy
    {
        UniTask ShowPanel(Panels panel,
            string address,
            IInstaller installer,
            Dictionary<Panels, (GameObject instance,
            AsyncOperationHandle<GameObject> handle, LifetimeScope lifetimeScope)> loadedPanels,
            Panels currentActivePanel);
    }
}
