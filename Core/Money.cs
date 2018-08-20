namespace Automagic.DomainModels.Core
{
    public abstract class Money : ValueObject<Money>
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        protected Money(decimal amount, Currency currency)
        {
            currency.EnsureValueObject("Specify a currency.", typeof(Money), typeof(Currency));

            Amount = amount;
            Currency = currency;
        }

        protected override bool DoEqualityCheck(Money a, Money b)
        {
            return a.Amount == b.Amount &&
                   a.Currency == b.Currency;
        }

        protected override HashCode CalculateHashCode()
        {
            //TODO: refactor to Core.

            var hashCode = 385229220;
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            hashCode = hashCode * -1521134295 + Currency.GetHashCode();

            return new HashCode(hashCode);
        }
    }
}
