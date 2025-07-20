using Cysharp.Threading.Tasks;

namespace DenisKim.Core.Domain
{
    public interface IUIService : IService
    {
        UniTask ShowPanel();
        void HidePanel();
    }
}