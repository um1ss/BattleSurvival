using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;

namespace DenisKim.Core.Domain
{
    public interface ISceneTransitionService
    {
        UniTask Load(ISceneTransitionStrategy sceneTransitionStrategy, int sceneId);
    }
}