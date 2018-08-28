namespace Automagic.DomainModels.Core
{
    public sealed class UnitAbbreviation : Text 
    {
        public UnitAbbreviation(string value) : base(value)
        {
            value.EnsureStringSpecified("Specify the abbreviation.", typeof(UnitAbbreviation));
        }
    }
}
