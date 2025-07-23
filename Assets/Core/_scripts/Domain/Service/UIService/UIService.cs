using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using VContainer;

namespace DenisKim.Core.Domain
{
    public sealed class UIService : IUIService
    {
        #region Services
        readonly IAssetLoadingService _assetLoadingService;
        #endregion

        readonly Canvas _canvas;
        readonly Dictionary<PanelsEnum, (GameObject instance, AsyncOperationHandle<GameObject> handle)> _loadedUIPanels;

        GameObject _currentActivePanel;

        [Inject]
        public UIService(Canvas canvas, DontDestroyAssetLoadingStrategy dontDestroyAssetLoadingStrategy, IAssetLoadingService assetLoadingService)
        {
            _canvas = canvas;
            _assetLoadingService = assetLoadingService;
            _loadedUIPanels = new Dictionary<PanelsEnum, (GameObject, AsyncOperationHandle<GameObject>)>();
        }

        public async UniTask AddPanelDictionary(PanelsEnum panel, string address)
        {
            var handle = await _assetLoadingService.GetAssetLink<GameObject>(address);
            var instance = await _assetLoadingService.InstantiateGameObject(await _assetLoadingService.GetAssetLink<GameObject>(address),
                _canvas?.transform);
            instance.SetActive(false);
            _loadedUIPanels.Add(panel, (instance, handle));
        }
    }
}
