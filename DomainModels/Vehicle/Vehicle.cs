using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Vehicle : Entity<VehicleId>
    {
        public Vin Vin { get; }
        public Year Year { get; }
        public Make Make { get; }

        private Vehicle(VehicleId id, Vin vin, Year year, Make make) : base(id)
        {
            id.EnsureValueObject("Specify a vehicle id.", typeof(Vehicle), typeof(VehicleId));
            vin.EnsureValueObject("Specify a vin.", typeof(Vehicle), typeof(Vin));
            year.EnsureValueObject("Specify a year.", typeof(Vehicle), typeof(Year));
            make.EnsureValueObject("Specify a make.", typeof(Vehicle), typeof(Make));

            Vin = vin;
            Year = year;
            Make = make;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Id.GetHashCode());
        }

        protected override bool DoEqualityCheck(VehicleId a, VehicleId b)
        {
            return a == b;
        }

        public static Vehicle Create(VehicleId id, Vin vin, Year year, Make make)
        {
            return new Vehicle(id, vin, year, make);
        }
    }
}
