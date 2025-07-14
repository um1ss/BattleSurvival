using DenisKim.Core.Domain;
using System.Collections.Generic;

namespace DenisKim.Core.Application
{
    public abstract class BasePublisher : IPublisher
    {
        protected List<IListener> _listeners;
        protected BasePublisher()
        {
            _listeners = new List<IListener>();
        }
        public void AddListener(IListener listener)
        {
            _listeners.Add(listener);
        }

        public void NotifyListener()
        {
            foreach (IListener listener in _listeners)
            {
                listener.OnNotify();
            }
        }

        public void RemoveListener(IListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}