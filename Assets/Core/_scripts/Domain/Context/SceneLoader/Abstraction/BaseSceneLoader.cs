using DenisKim.Core.Insfrastructure;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Domain
{
    public abstract class BaseSceneLoader : BaseContext
    {
        readonly LifetimeScope _rootLifetimeScope;
        protected ILoadedScene _currentBehavior;

        public BaseSceneLoader(LifetimeScope rootLifetimeScope, ILoadedScene behavior)
        {
            _rootLifetimeScope = rootLifetimeScope;
            ChangeBehavior(behavior);
        }

        public override void ChangeBehavior(IBehavior newBehavior)
        {
            _currentBehavior = (ILoadedScene)newBehavior;
        }

        public virtual void Load()
        {
            _currentBehavior.Load(_rootLifetimeScope, "MainMenu");
        }
    }
}
