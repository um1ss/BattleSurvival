using R3;

namespace DenisKim.Core.Infrastructure
{
    public sealed class NegativeCurrencyStrategy : IChangeCurrencyStrategy
    {
        public int ChangeCurrency(int currencyValue, int value)
        {
            return currencyValue -= value;
        }
    }
}
