using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public class Vehicle : Entity<VehicleId>
    {
        public Vehicle(VehicleId id) : base(id)
        {
            id.EnsureValueObject("Specify a vehicle id.", typeof(Vehicle), typeof(VehicleId));
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Id.GetHashCode());
        }

        protected override bool DoEqualityCheck(VehicleId a, VehicleId b)
        {
            return a == b;
        }
    }
}
