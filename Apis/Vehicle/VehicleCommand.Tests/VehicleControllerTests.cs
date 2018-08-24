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
            
            var expectedVehicleId = "123";

            // Act
            var response = await EnsurePostAsync("api/v1.0/vehicle", new AddVehicleRequest {VehicleId = expectedVehicleId});

            // Assert
            
            var responseModel = await response.Content.ReadAsAsync<AddVehicleResponse>();
            responseModel.VehicleId.Should().Be(expectedVehicleId);

        }
    }
}
