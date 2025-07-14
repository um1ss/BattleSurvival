using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DenisKim.Core.Insfrastructure
{
    public interface IStateMachine
    {
        void ChangeState(IState state);
    }
}
