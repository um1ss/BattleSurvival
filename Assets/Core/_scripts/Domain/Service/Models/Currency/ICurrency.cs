using DenisKim.Core.Infrastructure;
using R3;

namespace DenisKim.Core.Domain
{
    public interface ICurrency
    {
        ReadOnlyReactiveProperty<int> Currency { get; }

        void ChangeCurrency(IChangeCurrencyStrategy changeCurrencyStrategy, int value);
    }
}
