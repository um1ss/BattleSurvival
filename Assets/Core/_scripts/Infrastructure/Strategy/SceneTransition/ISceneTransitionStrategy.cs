using Cysharp.Threading.Tasks;

namespace DenisKim.Core.Infrastructure
{
    public interface ISceneTransitionStrategy
    {
        UniTask Load(int sceneId);
    }
}
