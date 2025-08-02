using R3;
using System;

namespace DenisKim.Core.Application
{
    public abstract class BaseViewModel : IDisposable
    {
        protected readonly CompositeDisposable _compositeDisposable;

        protected BaseViewModel()
        {
            _compositeDisposable = new();
        }

        public virtual void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}
