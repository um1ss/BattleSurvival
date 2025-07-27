using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace DenisKim.Core.Domain
{
    public interface IUIService
    {
        UniTask ShowOnDemandLoadingPanel(Panels panel, string address, IInstaller installer);
        UniTask ShowPersistentPanel(Panels panel, string address, IInstaller installer);
    }
}