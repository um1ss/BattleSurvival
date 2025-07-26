using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace DenisKim.Core.Domain
{
    public interface IUIService
    {
        UniTask ShowOnDemandLoadingPanel(PanelsEnum panel, string address, IInstaller installer);
        UniTask ShowPersistentPanel(PanelsEnum panel, string address, IInstaller installer);
    }
}