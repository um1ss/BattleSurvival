using VContainer;
using VContainer.Unity;
using DenisKim.Core.Insfrastructure;

namespace DenisKim.Core.Domain
{
    public class SceneLoader : BaseContext
    {
        readonly LifetimeScope _rootLifetimeScope;
        protected ILoadedScene _currentBehavior;

        [Inject]
        public SceneLoader(LifetimeScope rootLifetimeScope, LoadedScene behavior) : base(behavior)
        {
            _rootLifetimeScope = rootLifetimeScope;
        }

        public override void ChangeBehavior(IBehavior newBehavior)
        {
            _currentBehavior = (ILoadedScene)newBehavior;
        }

        public void Load()
        {
            _currentBehavior.Load(_rootLifetimeScope, "MainMenu");
        }
    }
}
