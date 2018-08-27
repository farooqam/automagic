using System.Collections.Generic;
using System.Net;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Core.Api;
using Microsoft.AspNetCore.Mvc;

namespace Automagic.Apis.Vehicle.VehicleCommand.Controllers
{
    [Route("api/v1.0/vehicle")]
    [Produces("application/json")]
    public class VehicleController : Controller
    {
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(AddVehicleResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(IEnumerable<ModelError>))]
        public IActionResult AddVehicle([FromBody] AddVehicleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetModelErrors());
            }

            return Ok(new AddVehicleResponse {VehicleId = "123"});
        }
    }
}
