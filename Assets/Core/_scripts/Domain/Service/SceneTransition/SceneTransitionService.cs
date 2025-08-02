using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace DenisKim.Core.Domain
{
    public sealed class SceneTransitionService : ISceneTransitionService
    {
        readonly LifetimeScope _rootLifetimeScope;

        public SceneTransitionService(LifetimeScope rootLifetimeScope)
        {
            _rootLifetimeScope = rootLifetimeScope;
        }

        public async UniTask LoadSceneAsync(SceneIndex sceneID)
        {
            using (LifetimeScope.EnqueueParent(_rootLifetimeScope))
            {
                await SceneManager.LoadSceneAsync((int)sceneID, LoadSceneMode.Single);
            }
        }
    }
}
