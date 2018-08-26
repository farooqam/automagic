using System;
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
                CreateDefaultAddVehicleRequest(),
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
                response => true.Should().BeFalse(),
                response => { response.AssertErrorExists(string.Empty, "A non-empty request body is required."); });

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
                CreateDefaultAddVehicleRequest().UpdateVin(vin),
                response => true.Should().BeFalse(),
                response => { response.AssertErrorExists("Vin", "Specify a vin."); });
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
                CreateDefaultAddVehicleRequest().UpdateVin(vin),
                response => true.Should().BeFalse(),
                response => { response.AssertErrorExists("Vin", "A valid VIN is 17 characters in length."); });
        }

        [Theory]
        [InlineData(1980)]
        [InlineData(2020)]
        public async Task AddVehicle_WhenYearNotInRange_ReturnsBadRequest(short year)
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateYear(year),
                response => true.Should().BeFalse(),
                response => { response.AssertErrorExists("Year", $"Year must be between 1981 and {DateTime.Today.Year + 1}"); });
        }

        private static AddVehicleRequest CreateDefaultAddVehicleRequest()
        {
            return new AddVehicleRequest
            {
                // ReSharper disable once StringLiteralTypo
                Vin = "123456789ABCDEFGH"
            };
        }

    }
}
