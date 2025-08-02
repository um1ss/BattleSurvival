using DenisKim.Core.Infrastructure;
using R3;

namespace DenisKim.Core.Domain
{
    public abstract class BaseCurrency : ICurrency
    {
        protected readonly ReactiveProperty<int> _currency;
        public ReadOnlyReactiveProperty<int> Currency { get; }

        protected BaseCurrency(int value)
        {
            _currency = new ReactiveProperty<int>();
            Currency = _currency.ToReadOnlyReactiveProperty();
            SetCurrency(value);
        }

        public void ChangeCurrency(IChangeCurrencyStrategy changeCurrencyStrategy, int value)
        {
            SetCurrency(changeCurrencyStrategy.ChangeCurrency(_currency.Value, value));
        }

        protected void SetCurrency(int value)
        {
            _currency.Value = value;
        }
    }
}
