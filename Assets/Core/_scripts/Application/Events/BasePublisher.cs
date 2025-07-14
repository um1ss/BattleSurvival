using System.Collections;
using System.Collections.Generic;
using DenisKim.Core.Domain;
using UnityEngine;

namespace DenisKim.Core.Application
{
    public abstract class BasePublisher : IPublisher
    {
        protected List<IListener> _listeners;
        protected BasePublisher()
        {
            _listeners = new List<IListener>();
        }
        public virtual void AddListener(IListener listener)
        {
            _listeners.Add(listener);
        }

        public virtual void NotifyListener()
        {
            foreach (var listener in _listeners)
            {
                listener.OnNotify();
            }
        }

        public virtual void RemoveListener(IListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
