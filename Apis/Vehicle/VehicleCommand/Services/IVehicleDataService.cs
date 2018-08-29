using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;

namespace Automagic.Apis.Vehicle.VehicleCommand.Services
{
    public interface IVehicleDataService
    {
        Task<AddVehicleResponse> SaveVehicleAsync(string vehicleId, AddVehicleRequest request);
    }
}
