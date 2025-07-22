using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;

namespace DenisKim.Core.Domain
{
    public interface IUIService
    {
        UniTask CreatePersistentPanels(IRootCanvasStrategy rootCanvasStrategy);
        void ShowPanel();
        void HidePanel();
    }
}