using DenisKim.Core.Infrastructure;
using R3;

namespace DenisKim.Core.Domain
{
    public sealed class HardCurrencyService : BaseCurrency
    {
        public HardCurrencyService(int value) : base(value)
        {
            SetCurrency(value);
        }
    }
}
