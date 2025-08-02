using R3;

namespace DenisKim.Core.Infrastructure
{
    public interface IChangeCurrencyStrategy
    {
        int ChangeCurrency(int currencyValue, int value);
    }
}
