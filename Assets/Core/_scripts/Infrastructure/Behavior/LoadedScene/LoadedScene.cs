using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace DenisKim.Core.Insfrastructure
{
    public class LoadedScene : ILoadedScene
    {
        public async UniTask Load(LifetimeScope rootLifetimeScope, string sceneName)
        {
            using (LifetimeScope.EnqueueParent(rootLifetimeScope))
            {
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
        }
    }
}
