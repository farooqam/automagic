using Core.Api;

namespace Automagic.Apis.Vehicle.VehicleCommand.Models
{
    public sealed class AddVehicleRequest : IRequestModel 
    {
        public VehicleType Type { get; set; }
        public string Vin { get; set; }
        public short Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public decimal Price { get; set; }
        public decimal Odometer { get; set; }
        public Unit OdometerUnit { get; set; }
    }

    public enum VehicleType
    {
        NotSpecified,
        New,
        Used,
        Certified
    }

    public enum Unit
    {
        NotSpecified,
        Miles
    }
}
