namespace Automagic.DomainModels.Core
{
    public class UnitAbbreviation : Text 
    {
        public UnitAbbreviation(string value) : base(value)
        {
            value.EnsureStringSpecified("Specify the abbreviation.", typeof(UnitAbbreviation));
        }
    }
}
