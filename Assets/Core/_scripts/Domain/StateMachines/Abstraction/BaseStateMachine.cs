using DenisKim.Core.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DenisKim.Core.Infrastructure
{
    public abstract class BaseStateMachine : IStateMachine
    {
        protected IState _state;
        protected BaseStateMachine(IState state)
        {
            ChangeState(state);
        }
        public virtual void ChangeState(IState state)
        {
            _state = state;
        }
    }
}
