using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Apis.Vehicle.VehicleCommand.Services;
using Core.Api;
using Microsoft.AspNetCore.Mvc;

namespace Automagic.Apis.Vehicle.VehicleCommand.Controllers
{
    [Route("api/v1/vehicle")]
    [Produces("application/json")]
    public sealed class VehicleController : Controller
    {
        private readonly IVehicleDataService _vehicleDataService;
        private readonly IVehicleIdService _vehicleIdService;

        public VehicleController(IVehicleDataService vehicleDataService, IVehicleIdService vehicleIdService)
        {
            _vehicleDataService = vehicleDataService;
            _vehicleIdService = vehicleIdService;
        }

    /// <summary>
    /// Adds a Vehicle to the tenant.
    /// </summary>
    /// <remarks>
    ///Sample request:
    ///
    ///     POST /api/v1/vehicle
    ///     {
    ///         "type": 1,
    ///         "vin": "AAAAAAAAAAAAAAAAA",
    ///         "year": 2016,
    ///         "make": "Honda",
    ///         "model": "Accord",
    ///         "trim": "EX",
    ///         "price": 29995,
    ///         "odometer": 12,
    ///         "odometerUnit": "miles"
    ///     }
    ///        
    ///     
    /// </remarks>
    /// <param name="request"></param>
    /// <returns>The added vehicle's id and self link.</returns>
    /// <response code="200">Returns the added vehicle.</response>
    /// <response code="400">The request failed validation.</response>
    [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(AddVehicleResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ModelError>))]
        public async Task<IActionResult> AddVehicleAsync([FromBody] AddVehicleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetModelErrors());
            }

            var vehicleId = await _vehicleIdService.NewId(request);
            var response = await _vehicleDataService.SaveVehicle(vehicleId, request);
            return Ok(response);
        }
    }
}
