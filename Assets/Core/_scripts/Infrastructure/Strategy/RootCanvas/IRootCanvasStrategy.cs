using Cysharp.Threading.Tasks;

namespace DenisKim.Core.Infrastructure
{
    public interface IRootCanvasStrategy
    {
        UniTask CreatePanel();
    }
}