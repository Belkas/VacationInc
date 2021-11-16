using Application.Assets.Queries;
using Application.Orders.Commands.CreateOrder;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vacation_Inc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleOrderController : ApiControllerBase
    {

        [HttpGet]
        public async Task<List<VehicleOrder>> Get()
        {
            var result = await Mediator.Send(new GetVehicleOrdersQuery());
            return result;
        }

        [HttpPost]
        [Route("Create")]
        public async Task CreateVehicleOrder(CreateVehicleOrderCommand command)
        {
            await Mediator.Send(command);
        }

        [HttpPost]
        [Route("Confirm")]
        public async Task ConfirmVehicleOrder(CreateVehicleOrderCommand command)
        {
            await Mediator.Send(command);
        }

        [HttpPost]
        [Route("Return")]
        public async Task Return(ReturnVehicleCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
