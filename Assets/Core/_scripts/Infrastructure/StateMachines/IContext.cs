using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DenisKim.Core.Insfrastructure
{
    public interface IContext
    {
        void UpdateState(IState state);
    }
}
