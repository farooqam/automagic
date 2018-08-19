using System;
using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class VehicleId : ValueObject<VehicleId>, IComparable<VehicleId>
    {
        public string Value { get; }

        public VehicleId(string value)
        {
            value.EnsureStringSpecified("Specify a vehicle id.", typeof(VehicleId));

            Value = value;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Value.ToLowerInvariant().GetHashCode());
        }

        protected override bool DoEqualityCheck(VehicleId a, VehicleId b)
        {
            return CompareTo(b) == 0;
        }

        public int CompareTo(VehicleId other)
        {
            return string.Compare(Value, other.Value, StringComparison.OrdinalIgnoreCase);
        }
    }
}