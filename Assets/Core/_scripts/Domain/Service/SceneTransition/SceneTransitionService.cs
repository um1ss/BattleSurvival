using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;
using UnityEngine.SceneManagement;

namespace DenisKim.Core.Domain
{
    public sealed class SceneTransitionService : ISceneTransitionService
    {
        public async UniTask Load(ISceneTransitionStrategy sceneTransitionStrategy, int sceneId)
        {
            await sceneTransitionStrategy.Load(sceneId);
        }
    }
}
