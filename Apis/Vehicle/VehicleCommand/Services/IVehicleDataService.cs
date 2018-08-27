using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;

namespace Automagic.Apis.Vehicle.VehicleCommand.Services
{
    public interface IVehicleDataService
    {
        Task<AddVehicleResponse> SaveVehicle(string vehicleId, AddVehicleRequest request);
    }
}
