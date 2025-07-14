using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DenisKim.Core.Domain;

namespace DenisKim.Core.Application
{
    public interface IPublisher 
    {
        void AddListener(IListener listener);
        void RemoveListener(IListener listener);
        void NotifyListener();

    }
}
