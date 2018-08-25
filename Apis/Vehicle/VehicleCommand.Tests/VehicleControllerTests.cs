using System.Net;
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

            // Act and Assert
            await Post(
                "api/v1.0/vehicle", 
                new AddVehicleRequest {Vin = new Vin().Value}, 
                response =>
                {
                    response.AssertStatusCode(HttpStatusCode.OK);
                    var responseModel = response.GetResponseModel<AddVehicleResponse>().Result;
                    responseModel.VehicleId.Should().Be(expectedVehicleId);
                });
        }

        [Fact]
        public async Task AddVehicle_WhenRequestNotSpecified_ReturnsBadRequest()
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle", 
                null as AddVehicleRequest,
                null, 
                response =>
                {
                    response.AssertErrorExists(string.Empty, "A non-empty request body is required.");
                });

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task AddVehicle_WhenVinNotSpecified_ReturnsBadRequest(string vin)
        {
            // Arrange
            
            // Act & Assert
            await Post(
                "api/v1.0/vehicle", 
                new AddVehicleRequest {Vin = vin},
                null,
                response => {
                    response.AssertErrorExists("Vin", "Specify a vin.");
                });
        }

        [Theory]
        // ReSharper disable once StringLiteralTypo
        [InlineData("1234567890ABCDEFGH")]
        [InlineData("1234567890ABCDEF")]
        public async Task AddVehicle_WhenVinNotRightLength_ReturnsBadRequest(string vin)
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                new AddVehicleRequest { Vin = vin },
                null,
                response => {
                    response.AssertErrorExists("Vin", "A valid VIN is 17 characters in length.");
                });
        }

    }

    public class Vin
    {
        // ReSharper disable once StringLiteralTypo
        public string Value { get; } = "123456789ABCDEFGH";
    }

}
