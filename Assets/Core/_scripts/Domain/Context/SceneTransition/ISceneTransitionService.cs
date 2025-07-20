using Cysharp.Threading.Tasks;

namespace DenisKim.Core.Domain
{
    public interface ISceneTransitionService
    {
        UniTask Load(int sceneIndex);
    }
}