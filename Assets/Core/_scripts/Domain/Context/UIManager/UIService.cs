//using Cysharp.Threading.Tasks;
//using DenisKim.Core.Infrastructure;
//using DenisKim.Core.Presentation;
//using System.Collections.Generic;
//using DenisKim.Core.Domain;
//using UnityEngine;

//namespace DenisKim.Core.Domain
//{
//    public sealed class UIService : MonoBehaviour, IUIService
//    {
//        IAssetLoadingService _assetLoadingService;
//        IUIManagerStrategy _iUIManagerBehavior;
//        public UIService(IAssetLoadingService assetLoadingStrategy, UIManagerStrategy newStrategy) : base(newStrategy)
//        {
//            _assetLoadingService = assetLoadingStrategy;
//            ChangeBehavior(newStrategy);
//        }

//        public override void ChangeBehavior(IStrategy newStrategy)
//        {
//            _iUIManagerBehavior = (IUIManagerStrategy)newStrategy;
//        }

//        public void CreateView(string prefabPath)
//        {
//            //_assetLoadingService.InstantiateObject(prefabPath, true, );
//        }

//        public void HidePanel()
//        {
//            throw new System.NotImplementedException();
//        }

//        public async UniTask ShowPanel()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
