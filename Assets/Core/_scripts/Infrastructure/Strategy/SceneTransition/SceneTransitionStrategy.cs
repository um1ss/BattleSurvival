using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace DenisKim.Core.Infrastructure
{
    public sealed class SceneTransitionStrategy : ISceneTransitionStrategy
    {
        public async UniTask Load(int sceneId)
        {
            await SceneManager.LoadSceneAsync(sceneId, LoadSceneMode.Single);
        }
    }
}