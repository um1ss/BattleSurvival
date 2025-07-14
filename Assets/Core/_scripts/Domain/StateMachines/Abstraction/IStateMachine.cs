using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DenisKim.Core.Infrastructure
{
    public interface IStateMachine
    {
        void ChangeState(IState state);
    }
}
