using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure
{
    public interface IShowPanelStrategy
    {
        void ShowPanel(ref PanelsEnum currentActivePanel,
            Dictionary<PanelsEnum, (GameObject instance, AsyncOperationHandle<GameObject> handle)> loadedUIPanels,
            PanelsEnum panel);
    }
}