using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;

namespace Automagic.Apis.Vehicle.VehicleCommand.Services
{
    public class VehicleIdService : IVehicleIdService
    {
        private readonly SHA256 _sha256 = SHA256.Create();
        private readonly Encoding _encoding = Encoding.UTF8;

        public Task<string> NewId(AddVehicleRequest request)
        {
            var hash = _sha256.ComputeHash(_encoding.GetBytes(request.Vin));
            return Task.FromResult(AsString(hash));
        }

        private string AsString(byte[] hash)
        {
            var sb = new StringBuilder();

            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}