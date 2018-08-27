using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Apis.Vehicle.VehicleCommand.Services;
using Core.Api;
using Microsoft.AspNetCore.Mvc;

namespace Automagic.Apis.Vehicle.VehicleCommand.Controllers
{
    [Route("api/v1.0/vehicle")]
    [Produces("application/json")]
    public class VehicleController : Controller
    {
        private readonly IVehicleDataService _vehicleDataService;
        private readonly IVehicleIdService _vehicleIdService;

        public VehicleController(IVehicleDataService vehicleDataService, IVehicleIdService vehicleIdService)
        {
            _vehicleDataService = vehicleDataService;
            _vehicleIdService = vehicleIdService;
        }

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
