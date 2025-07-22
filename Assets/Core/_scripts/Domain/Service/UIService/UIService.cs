using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;
using DenisKim.Core.Presentation;
using System.Collections.Generic;
using DenisKim.Core.Domain;
using UnityEngine;

namespace DenisKim.Core.Domain
{
    public sealed class UIService : IUIService
    {
        IAssetLoadingService _assetLoadingService;

        public UniTask CreatePersistentPanels(IRootCanvasStrategy rootCanvasStrategy)
        {
            throw new System.NotImplementedException();
        }

        public void CreateView(string prefabPath)
        {
            //_assetLoadingService.InstantiateObject(prefabPath, true, );
        }

        public void HidePanel()
        {
            throw new System.NotImplementedException();
        }

        public async UniTask ShowPanel()
        {
            throw new System.NotImplementedException();
        }

        void IUIService.ShowPanel()
        {
            throw new System.NotImplementedException();
        }
    }
}
