namespace Automagic.DomainModels.Core
{
    public sealed class Currency : ValueObject<Currency>
    {
        public CurrencyAbbreviation Abbreviation { get; }

        internal Currency(CurrencyAbbreviation abbreviation)
        {
            Abbreviation = abbreviation;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Abbreviation.GetHashCode());
        }

        protected override bool DoEqualityCheck(Currency a, Currency b)
        {
            return a.Abbreviation == b.Abbreviation;
        }
    }

    public sealed class Currencies
    {
        public static Currency UnitedStatesDollar = new Currency(new CurrencyAbbreviation("USD"));
    }
}
