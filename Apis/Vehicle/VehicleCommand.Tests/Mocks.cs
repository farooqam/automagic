using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Apis.Vehicle.VehicleCommand.Services;
using Moq;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests
{
    public class MockVehicleDataService : Mock<IVehicleDataService>
    {
        public MockVehicleDataService()
        {
            Setup(m => m.SaveVehicle(It.IsAny<string>(), It.IsAny<AddVehicleRequest>()))
                .ReturnsAsync(new AddVehicleResponse());
        }
    }

    public class MockVehicleIdService : Mock<IVehicleIdService>
    {
        public MockVehicleIdService()
        {
            Setup(m => m.NewId(It.IsAny<AddVehicleRequest>()))
                .ReturnsAsync(string.Empty);
        }
    }

}
