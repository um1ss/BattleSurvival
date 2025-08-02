using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DenisKim.Core.Presentation
{
    public abstract class BaseView : MonoBehaviour
    {
        protected CompositeDisposable _compositeDisposable;

        protected virtual void Awake()
        {
            _compositeDisposable = new();
        }

        protected virtual void OnDestroy()
        {
            _compositeDisposable.Dispose();
        }
    }
}
