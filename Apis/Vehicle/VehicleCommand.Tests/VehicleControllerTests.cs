using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Core.Api.Tests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests
{
    public class VehicleControllerTests : ApiTestClassFixture<Startup>
    {

        public VehicleControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }
        
        [Fact]
        public async Task AddVehicle_ReturnsResponseModel()
        {
            // Arrange
            var expectedVehicleId = "123";

            // Act
            var response = await EnsurePost("api/v1.0/vehicle", new AddVehicleRequest {Vin = "vin123"}, HttpStatusCode.OK);

            // Assert
            
            var responseModel = await response.Content.ReadAsAsync<AddVehicleResponse>();
            responseModel.VehicleId.Should().Be(expectedVehicleId);

        }

        [Fact]
        public async Task AddVehicle_WhenRequestNotSpecified_ReturnsBadRequest()
        {
            // Arrange

            // Act & Assert
            await EnsurePost("api/v1.0/vehicle", null as AddVehicleRequest, HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task AddVehicle_WhenVinNotSpecified_ReturnsBadRequest()
        {
            // Arrange
            
            // Act & Assert
            await EnsurePost("api/v1.0/vehicle", new AddVehicleRequest(), HttpStatusCode.BadRequest);
            
        }
    }
}
