using Cysharp.Threading.Tasks;

namespace DenisKim.Core.Infrastructure
{
    public interface IUIManagerStrategy : IStrategy
    {
        void CreateView(string prefabPath);
        UniTask ShowPanel();
        void HidePanel();
    }
}