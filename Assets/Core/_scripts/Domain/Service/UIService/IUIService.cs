using Cysharp.Threading.Tasks;
using DenisKim.Core.Infrastructure;

namespace DenisKim.Core.Domain
{
    public interface IUIService
    {
        public UniTask AddPanelDictionary(PanelsEnum panel, string address);
    }
}