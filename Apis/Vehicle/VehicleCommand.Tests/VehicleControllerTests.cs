using Automagic.Apis.Vehicle.VehicleCommand.Controllers;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests
{
    public class VehicleControllerTests
    {
        [Fact]
        public void AddVehicle_ReturnsResponse()
        {
            // Arrange
            var controller = new VehicleController();
            var request = new AddVehicleRequest();

            // Act
            var response = controller.AddVehicle(request) as CreatedAtRouteResult;

            // Assert
            response.Should().NotBeNull();
        }
    }
}
