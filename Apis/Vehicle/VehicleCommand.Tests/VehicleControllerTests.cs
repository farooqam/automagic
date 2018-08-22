using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests
{
    public class VehicleControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public VehicleControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task AddVehicle_ReturnsSuccess()
        {
            // Arrange
            var client = _factory.CreateClient();
            var content = new ObjectContent<AddVehicleRequest>(
                new AddVehicleRequest(), 
                new JsonMediaTypeFormatter
                {
                    SerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                });

            // Act
            var response = await client.PostAsync("api/v1.0/vehicle", content);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddVehicle_ReturnsResponseModel()
        {
            // Arrange
            var client = _factory.CreateClient();

            var content = new ObjectContent<AddVehicleRequest>(
                new AddVehicleRequest(),
                new JsonMediaTypeFormatter
                {
                    SerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                });

            var expectedVehicleId = "123";

            // Act
            var response = await client.PostAsync("api/v1.0/vehicle", content);

            // Assert
            response.EnsureSuccessStatusCode();

            var responseModel = await response.Content.ReadAsAsync<AddVehicleResponse>();
            responseModel.VehicleId.Should().Be(expectedVehicleId);

        }
    }
}
