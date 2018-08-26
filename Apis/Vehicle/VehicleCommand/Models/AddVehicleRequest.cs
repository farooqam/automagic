using Core.Api;

namespace Automagic.Apis.Vehicle.VehicleCommand.Models
{
    public class AddVehicleRequest : IRequestModel 
    {
        public VehicleType Type { get; set; }
        public string Vin { get; set; }
        public short Year { get; set; }
        
    }

    public enum VehicleType
    {
        New,
        Used,
        Certified
    }
}
