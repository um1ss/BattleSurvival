using Cysharp.Threading.Tasks;

namespace DenisKim.Core.Domain
{
    public interface IGlobalObjectsService
    {
        public UniTask CreateInstance(string address);
    }
}
