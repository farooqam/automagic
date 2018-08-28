using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Apis.Vehicle.VehicleCommand.Services;
using Moq;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests
{
    public sealed class MockVehicleDataService : Mock<IVehicleDataService>
    {
        public MockVehicleDataService()
        {
            Setup(m => m.SaveVehicle(It.IsAny<string>(), It.IsAny<AddVehicleRequest>()))
                .ReturnsAsync(new AddVehicleResponse());
        }
    }

}
