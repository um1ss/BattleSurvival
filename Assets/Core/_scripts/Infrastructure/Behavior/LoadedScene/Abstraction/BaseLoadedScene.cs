using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace DenisKim.Core.Insfrastructure
{
    public abstract class BaseLoadedScene : ILoadedScene
    {
        public abstract UniTask Load(LifetimeScope rootLifetimeScope, string sceneName);
    }
}
