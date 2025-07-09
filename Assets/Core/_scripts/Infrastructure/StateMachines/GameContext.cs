using DenisKim.Core.Insfrastructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DenisKim.Core.Insfrastructure
{
    public class GameContext : AbstractContext
    {
        public GameContext(IState state) : base(state)
        {
        }
    }
}
