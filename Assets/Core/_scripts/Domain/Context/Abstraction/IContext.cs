using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DenisKim.Core.Insfrastructure;

namespace DenisKim.Core.Domain
{
    public interface IContext
    {
        void ChangeBehavior(IBehavior newBehavior);
    }
}
