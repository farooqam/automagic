using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;

namespace Automagic.Apis.Vehicle.VehicleCommand.Services
{
    public class FakeVehicleDataService : IVehicleDataService
    {
        public Task<AddVehicleResponse> SaveVehicle(string vehicleId, AddVehicleRequest request)
        {
            return Task.FromResult(new AddVehicleResponse
            {
                VehicleId = vehicleId
            });
        }
    }
}
