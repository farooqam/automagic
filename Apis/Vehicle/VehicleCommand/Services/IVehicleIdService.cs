using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;

namespace Automagic.Apis.Vehicle.VehicleCommand.Services
{
    public interface IVehicleIdService
    {
        Task<string> NewIdAsync(AddVehicleRequest request);
    }
}
