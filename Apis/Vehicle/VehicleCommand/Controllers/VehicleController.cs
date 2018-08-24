using System.Net;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
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
        public IActionResult AddVehicle([FromBody] AddVehicleRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(request.Vin))
            {
                return BadRequest();
            }

            return Ok(new AddVehicleResponse {VehicleId = "123"});
        }
    }
}
