using DenisKim.Core.Insfrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DenisKim.Core.Insfrastructure
{
    public abstract class AbstractContext : IContext
    {
        protected IState _state;
        protected AbstractContext(IState state)
        {
            UpdateState(state);
        }
        #region Constant Mehtod
        public virtual void UpdateState(IState state)
        {
            _state.ExitState();
            Debug.Log($"Context: Transition to {state.GetType().Name}.");
            _state = state;
            _state.EnterState();
        }
        #endregion
    }
}
