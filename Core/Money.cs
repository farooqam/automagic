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
    }
}
