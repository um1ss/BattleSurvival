using Cysharp.Threading.Tasks;

namespace DenisKim.Core.Domain
{
    public interface ISceneTransitionService
    {
        UniTask LoadSceneAsync(SceneIndex sceneID);
    }
}