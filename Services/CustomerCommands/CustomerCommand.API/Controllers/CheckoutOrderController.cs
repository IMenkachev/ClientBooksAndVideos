using CustomerCommands.Application.Features.Commands.Orders.CheckoutOrder;
using CustomerCommands.Application.Models.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerCommand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckoutOrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderVm>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
