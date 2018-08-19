using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Price : Money
    {
        public Price(decimal amount, Currency currency) : base(amount, currency)
        {
            amount.EnsureValueWithinRange(0, decimal.MaxValue, "Amount cannot be less than zero.", typeof(Price), null);
        }
    }
}



