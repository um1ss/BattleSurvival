using VContainer;
using VContainer.Unity;
using DenisKim.Core.Insfrastructure;

namespace DenisKim.Core.Domain
{
    public class SceneLoader : BaseSceneLoader
    {
        [Inject]
        public SceneLoader(LifetimeScope rootLifetimeScope, LoadedScene loadedScene) : base(rootLifetimeScope, loadedScene)
        {
        }
    }
}
