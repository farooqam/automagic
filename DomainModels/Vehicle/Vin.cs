using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Vin : Text
    {
        public Vin(string value) : base(value)
        {
            value.EnsureStringSpecified("Specify a vin.", typeof(Vin));
        }
        
    }
}
