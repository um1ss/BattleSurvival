using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using DenisKim.Core.Application;
using VContainer;

namespace DenisKim.Core.Infrastructure
{
    public abstract class BaseState : IState
    {
        protected readonly IStateMachine _stateMachine;
        
        protected BaseState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        protected virtual void ChangeState(IState state)
        {
            _stateMachine.ChangeState(state);
        }
    }
}
