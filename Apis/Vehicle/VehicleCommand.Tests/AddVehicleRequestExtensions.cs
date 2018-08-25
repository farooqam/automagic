using Automagic.Apis.Vehicle.VehicleCommand.Models;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests
{
    public static class AddVehicleRequestExtensions
    {
        public static AddVehicleRequest RemoveVin(this AddVehicleRequest request)
        {
            request.Vin = null;
            return request;
        }

        public static AddVehicleRequest UpdateVin(this AddVehicleRequest request, string vin)
        {
            request.Vin = vin;
            return request;
        }
    }
}
