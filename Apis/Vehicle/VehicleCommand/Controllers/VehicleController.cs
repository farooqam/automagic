﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Automagic.Apis.Vehicle.VehicleCommand.Controllers
{
    [Route("api/v1.0/vehicle")]
    public class VehicleController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(AddVehicleResponse), (int)HttpStatusCode.Created)]
        public IActionResult AddVehicle(AddVehicleRequest request)
        {
            throw new NotImplementedException();
        }
    }
}