using Core.Api;

namespace Automagic.Apis.Vehicle.VehicleCommand.Models
{
    public class AddVehicleResponse : IUniqueResource
    {
        public string  VehicleId { get; set; }

        public string SelfLink => $"api/v1.0/vehicles/{VehicleId}";
    }
}
