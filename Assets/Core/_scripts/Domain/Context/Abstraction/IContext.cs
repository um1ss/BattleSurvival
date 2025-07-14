using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DenisKim.Core.Infrastructure;

namespace DenisKim.Core.Domain
{
    public interface IContext
    {
        void ChangeBehavior(IBehavior newBehavior);
    }
}
