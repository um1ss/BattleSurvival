using DenisKim.Core.Application;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DenisKim.Core.Domain
{
    public abstract class AbstractListener : IListener
    {
        public abstract void OnNotify();
    }
}
