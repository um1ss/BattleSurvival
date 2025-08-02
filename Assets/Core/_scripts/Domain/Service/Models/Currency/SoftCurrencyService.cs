using DenisKim.Core.Infrastructure;
using R3;

namespace DenisKim.Core.Domain
{
    public sealed class SoftCurrencyService : BaseCurrency
    {
        public SoftCurrencyService(int value) : base(value)
        {
            SetCurrency(value);
        }
    }
}
