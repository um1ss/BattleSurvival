using DenisKim.Core.Domain;
using UnityEngine;

namespace DenisKim.Core
{
    public interface ICanvasService : IGlobalObjectsService
    {
        Transform GetTransform { get; }
    }
}
