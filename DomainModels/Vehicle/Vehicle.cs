using Automagic.DomainModels.Core;

namespace Automagic.DomainModels.Vehicle
{
    public sealed class Vehicle : Entity<VehicleId>
    {
        public Vin Vin { get; }
        public Year Year { get; }
        public Make Make { get; }
        public Model Model { get; }
        public Trim Trim { get; }
        public Exterior Exterior { get; }
        public Interior Interior { get; }
        public Price Price { get; }
        public Odometer Odometer { get; set; }

        private Vehicle(
            VehicleId id,
            Vin vin, 
            Year year, 
            Make make, 
            Model model,
            Trim trim,
            Exterior exterior,
            Interior interior,
            Price price,
            Odometer odometer) : base(id)
        {
            id.EnsureValueObject("Specify a vehicle id.", typeof(Vehicle), typeof(VehicleId));
            vin.EnsureValueObject("Specify a vin.", typeof(Vehicle), typeof(Vin));
            year.EnsureValueObject("Specify a year.", typeof(Vehicle), typeof(Year));
            make.EnsureValueObject("Specify a make.", typeof(Vehicle), typeof(Make));
            model.EnsureValueObject("Specify a model.", typeof(Vehicle), typeof(Model));
            trim.EnsureValueObject("Specify a trim.", typeof(Vehicle), typeof(Trim));
            exterior.EnsureValueObject("Specify an exterior object.", typeof(Vehicle), typeof(Exterior));
            interior.EnsureValueObject("Specify an interior object.", typeof(Vehicle), typeof(Interior));
            price.EnsureValueObject("Specify a price.", typeof(Vehicle), typeof(Price));
            odometer.EnsureValueObject("Specify an odometer object.", typeof(Vehicle), typeof(Odometer));

            Vin = vin;
            Year = year;
            Make = make;
            Model = model;
            Trim = trim;
            Exterior = exterior;
            Interior = interior;
            Price = price;
            Odometer = odometer;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Id.GetHashCode());
        }

        protected override bool DoEqualityCheck(VehicleId a, VehicleId b)
        {
            return a == b;
        }

        public static Vehicle Create(
            VehicleId id, 
            Vin vin, 
            Year year, 
            Make make, 
            Model model,
            Trim trim,
            Exterior exterior,
            Interior interior,
            Price price,
            Odometer odometer)
        {
            return new Vehicle(id, vin, year, make, model, trim, exterior, interior, price, odometer);
        }
    }
}
