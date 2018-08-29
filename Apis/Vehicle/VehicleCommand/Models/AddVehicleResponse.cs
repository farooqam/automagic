using Core.Api;

namespace Automagic.Apis.Vehicle.VehicleCommand.Models
{
    public sealed class AddVehicleResponse : IUniqueResource
    {
        public string  VehicleId { get; set; }

        public string SelfLink => $"api/v1/vehicles/{VehicleId}";
    }
}
