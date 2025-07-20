using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DenisKim.Core.Infrastructure;

namespace DenisKim.Core.Domain
{
    public interface IService
    {
        void ChangeBehavior(IStrategy newStrategy);
    }
}
