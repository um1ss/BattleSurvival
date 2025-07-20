using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace DenisKim.Core.Domain
{
    public sealed class SceneTransitionService : ISceneTransitionService
    {
        public async UniTask Load(int sceneIndex)
        {
            await SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        }
    }
}
