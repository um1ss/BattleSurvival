using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace DenisKim.Core.Infrastructure
{
    public interface ILoadedScene : IBehavior
    {
        UniTask Load(LifetimeScope rootLifetimeScope, string sceneName);
    }
}
