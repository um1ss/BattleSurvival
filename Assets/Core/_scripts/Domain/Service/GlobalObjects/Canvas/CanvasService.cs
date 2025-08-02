using UnityEngine;

namespace DenisKim.Core.Domain
{
    public sealed class CanvasService : BaseGlobalObjectsService, ICanvasService
    {
        public Transform GetTransform { get { return _instance.transform; } }
    }
}