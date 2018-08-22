using Automagic.Core.Api;

namespace Automagic.Apis.Vehicle.VehicleCommand.Models
{
    public class AddVehicleRequest : IRequestModel 
    {
        public string VehicleId { get; set; }
    }
}
