using System;
using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public class Vin : ValueObject<Vin>
    {
        public string Value { get; }

        public Vin(string value)
        {
            value.EnsureStringSpecified("Specify a vin.", typeof(Vin));

            Value = value;
        }
        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Value.ToLowerInvariant().GetHashCode());
        }

        protected override bool DoEqualityCheck(Vin a, Vin b)
        {
            return string.Compare(a.Value, b.Value, StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}
