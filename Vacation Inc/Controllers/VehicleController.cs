using Application.Vehicles.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vacation_Inc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ApiControllerBase
    {
        [HttpGet]
        public async Task<List<Vehicle>> GetVehicles()
        {
            var results = await Mediator.Send(new GetVehiclesQuery());
            return results;
        }
    }
}
