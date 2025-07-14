using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using DenisKim.Core.Application;
using VContainer;

namespace DenisKim.Core.Insfrastructure
{
    public abstract class BaseState : IState
    {
        protected IStateMachine _stateMachine;
        
        protected BaseState(IStateMachine stateMachine)
        {
            ChangeStateMachine(stateMachine);
        }
        protected virtual void ChangeStateMachine(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        protected virtual void ChangeState(IState state)
        {
            _stateMachine.ChangeState(state);
        }
        public virtual void EnterState()
        {
            Debug.Log($"{_stateMachine.GetType().Name} entered in {this.GetType().Name} State");
        }

        public virtual void ExitState()
        {
            Debug.Log($"{_stateMachine.GetType().Name} came out in {this.GetType().Name} State");
        }
    }
}
