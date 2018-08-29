using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Apis.Vehicle.VehicleCommand.Services;
using FluentAssertions;
using Xunit;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests.Services
{
    public sealed class VehicleIdServiceTests
    {
        [Fact]
        public async Task NewId_ReturnsAnId()
        {
            // Arrange
            var service = new VehicleIdService();
            var request = new AddVehicleRequest { Vin = "ABC1234" };

            // Act
            var id = await service.NewIdAsync(request);

            // Assert
            id.Should().Be("979AE4C32C826F265C49C0B17432FFB18C1BCCABC79CEDE66A99984403FC4AE4");
        }
    }
}
