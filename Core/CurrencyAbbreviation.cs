namespace Automagic.DomainModels.Core
{
    public class CurrencyAbbreviation : Text
    {
        public CurrencyAbbreviation(string value) : base(value)
        {
            value.EnsureStringSpecified("Specify an abbreviation.", typeof(CurrencyAbbreviation));
        }
    }
}
