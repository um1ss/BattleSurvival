using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DenisKim.Core.Infrastructure
{
    public sealed class ShowOnDemandLoadingPanelStrategy : IShowPanelStrategy
    {
        public void ShowPanel(ref PanelsEnum currentActivePanel,
            Dictionary<PanelsEnum, (GameObject instance, AsyncOperationHandle<GameObject> handle)> loadedUIPanels,
            PanelsEnum panel)
        {
            if (currentActivePanel != PanelsEnum.None)
            {
                loadedUIPanels[currentActivePanel].instance.SetActive(false);
            }
            currentActivePanel = panel;
            loadedUIPanels[currentActivePanel].instance.SetActive(true);
        }
    }
}