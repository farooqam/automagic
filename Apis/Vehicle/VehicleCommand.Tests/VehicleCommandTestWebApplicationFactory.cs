using System;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Apis.Vehicle.VehicleCommand.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests
{
    public class VehicleCommandTestWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        public Action<Mock<IVehicleDataService>> SetupMockDataService { get; set; }
        public Action<Mock<IVehicleIdService>> SetupMockIdService { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var mockDataService = new Mock<IVehicleDataService>();
            SetupMockDataService?.Invoke(mockDataService);

            var mockIdService = new Mock<IVehicleIdService>();
            SetupMockIdService?.Invoke(mockIdService);

            builder.ConfigureServices(services =>
            {
                services.TryAddTransient<IVehicleDataService>(provider => mockDataService.Object);
                services.TryAddTransient<IVehicleIdService>(provider => mockIdService.Object);
            });
        }
    }
}
