using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.Insfrastructure
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(LifetimeScope rootLifetimeScope, string sceneName);
    }
}
