using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Vehicle : Entity<VehicleId>
    {
        public Vin Vin { get; }

        private Vehicle(VehicleId id, Vin vin) : base(id)
        {
            id.EnsureValueObject("Specify a vehicle id.", typeof(Vehicle), typeof(VehicleId));
            vin.EnsureValueObject("Specify a vin.", typeof(Vehicle), typeof(Vin));

            Vin = vin;
            
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Id.GetHashCode());
        }

        protected override bool DoEqualityCheck(VehicleId a, VehicleId b)
        {
            return a == b;
        }

        public static Vehicle Create(VehicleId id, Vin vin)
        {
            return new Vehicle(id, vin);
        }
    }
}
