using System;
using System.Net;
using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Apis.Vehicle.VehicleCommand.Services;
using Automagic.Core.Api.Tests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Xunit;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests.Controllers
{
    public sealed class VehicleControllerTests : ApiTestClassFixture<Startup>
    {

        public VehicleControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task AddVehicle_ReturnsResponseModel()
        {
            // Arrange
            var expectedVehicleId = "123";

            var dataServiceMock = new Mock<IVehicleDataService>();
            dataServiceMock.Setup(m => m.SaveVehicle(It.IsAny<string>(), It.IsAny<AddVehicleRequest>()))
                .ReturnsAsync(new AddVehicleResponse { VehicleId = expectedVehicleId });

            // Act and Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest(),
                response =>
                {
                    response.AssertStatusCode(HttpStatusCode.OK);
                    var responseModel = response.GetResponseModel<AddVehicleResponse>().Result;
                    responseModel.VehicleId.Should().Be(expectedVehicleId);
                },
                AssertNotRun,
                services =>
                {
                    services.RemoveAll<IVehicleDataService>();
                    services.TryAddScoped(provider => dataServiceMock.Object);
                });
        }

        [Fact]
        public async Task AddVehicle_WhenSuccessful_HasSelfLinkInResponse()
        {
            // Arrange
            var expectedVehicleId = "123";

            var dataServiceMock = new Mock<IVehicleDataService>();
            dataServiceMock.Setup(m => m.SaveVehicle(It.IsAny<string>(), It.IsAny<AddVehicleRequest>()))
                .ReturnsAsync(new AddVehicleResponse { VehicleId = expectedVehicleId });

            // Act and Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest(),
                response =>
                {
                    response.AssertStatusCode(HttpStatusCode.OK);
                    var responseModel = response.GetResponseModel<AddVehicleResponse>().Result;
                    responseModel.SelfLink.Should().Be($"api/v1.0/vehicles/{responseModel.VehicleId}");
                },
                AssertNotRun,
                services =>
                {
                    services.TryAddScoped(provider => dataServiceMock.Object);
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
                AssertNotRun,
                response => { response.AssertErrorExists(string.Empty, "A non-empty request body is required."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
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
                CreateDefaultAddVehicleRequest().UpdateVin(vin),
                AssertNotRun,
                response => { response.AssertErrorExists("Vin", "Specify a vin."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
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
                CreateDefaultAddVehicleRequest().UpdateVin(vin),
                AssertNotRun,
                response => { response.AssertErrorExists("Vin", "A valid VIN is 17 characters in length."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Fact]
        public async Task AddVehicle_WhenYearTooLow_ReturnsBadRequest()
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateYear(1980),
                AssertNotRun,
                response => { response.AssertErrorExists("Year", $"Year must be between 1981 and {DateTime.Today.Year + 1}"); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Fact]
        public async Task AddVehicle_WhenYearTooHigh_ReturnsBadRequest()
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateYear((short)(DateTime.Today.Year + 2)),
                AssertNotRun,
                response => { response.AssertErrorExists("Year", $"Year must be between 1981 and {DateTime.Today.Year + 1}"); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Fact]
        public async Task AddVehicle_WhenTypeNotSpecified_ReturnsBadRequest()
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateType(VehicleType.NotSpecified),
                AssertNotRun,
                response => { response.AssertErrorExists("Type", "Specify the vehicle type."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task AddVehicle_WhenMakeNotSpecified_ReturnsBadRequest(string make)
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateMake(make),
                AssertNotRun,
                response => { response.AssertErrorExists("Make", "Specify a make."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task AddVehicle_WhenModelNotSpecified_ReturnsBadRequest(string model)
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateModel(model),
                AssertNotRun,
                response => { response.AssertErrorExists("Model", "Specify a model."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task AddVehicle_WhenTrimNotSpecified_ReturnsOk(string trim)
        {
            // Arrange
            
            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateTrim(trim),
                response => {response.AssertStatusCode(HttpStatusCode.OK);},
                AssertNotRun,
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task AddVehicle_WhenPriceOutOfRange_ReturnsBadRequest(decimal price)
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdatePrice(price),
                AssertNotRun,
                response => { response.AssertErrorExists("Price", "Price must be greater than zero."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Theory]
        [InlineData(-1)]
        public async Task AddVehicle_WhenOdometerOutOfRange_ReturnsBadRequest(decimal odometer)
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateOdometer(odometer),
                AssertNotRun,
                response => { response.AssertErrorExists("Odometer", "Odometer cannot be less than zero."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        [Fact]
        public async Task AddVehicle_WhenOdometerUnitNotSpecified_ReturnsBadRequest()
        {
            // Arrange

            // Act & Assert
            await Post(
                "api/v1.0/vehicle",
                CreateDefaultAddVehicleRequest().UpdateOdometerUnit(Unit.NotSpecified),
                AssertNotRun,
                response => { response.AssertErrorExists("OdometerUnit", "Specify the odometer unit."); },
                services =>
                {
                    services.TryAddScoped(provider => new MockVehicleDataService().Object);
                });
        }

        private static AddVehicleRequest CreateDefaultAddVehicleRequest()
        {
            return new AddVehicleRequest
            {
                // ReSharper disable once StringLiteralTypo
                Vin = "123456789ABCDEFGH",
                Year = 2016,
                Type = VehicleType.New,
                Make = "Ford",
                Model = "Edge",
                Trim = "Sport",
                Price = 45995m,
                Odometer = 0,
                OdometerUnit = Unit.Miles
            };
        }

    }
}
