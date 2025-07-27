using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;
using VContainer.Unity;

namespace DenisKim.Core.Domain
{
    public interface IUIService
    {
        UniTask ShowPanel(IShowPanelStrategy showPanelStrategy, Panels panel,
            string address,
            IInstaller installer);

        void HidePanel();
    }
}