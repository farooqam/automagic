using Core.Api;

namespace Automagic.Apis.Vehicle.VehicleCommand.Models
{
    public class AddVehicleRequest : IRequestModel 
    {
        public string Vin { get; set; }
        public short Year { get; set; }
    }
}
