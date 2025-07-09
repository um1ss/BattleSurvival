using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using DenisKim.Core.Application;

namespace DenisKim.Core.Insfrastructure
{
    public abstract class AbstractState : IState
    {
        protected IContext _context;
        protected AbstractState(IContext context)
        {
            SetContext(context);
        }
        #region Constant Method
        protected virtual void SetContext(IContext context)
        {
            _context = context;
        }

        protected virtual void UpdateState(IState state)
        {
            _context.UpdateState(state);
        }
        #endregion
        #region Ovveride Method
        public virtual void EnterState()
        {
            Debug.Log($"{_context.GetType().Name} entered in {this.GetType().Name} State");
        }

        public virtual void ExitState()
        {
            Debug.Log($"{_context.GetType().Name} came out in {this.GetType().Name} State");
        }
        #endregion
    }
}
