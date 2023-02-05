using CustomerCommands.Application.Features.Customers.Commands.AddCustomer;
using CustomerCommands.Application.Features.Customers.Commands.DeleteCustomer;
using CustomerCommands.Application.Features.Customers.Commands.UpdateCustomer;
using CustomerCommands.Application.Features.Customers.Queries.GetCustomers;
using CustomerCommands.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerCommands.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerCommandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerCommandsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var query = new GetCustomersQuery();
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }

        [HttpPut("[action]")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpdateCustomer([FromBody]UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("[action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddCustomer([FromBody]AddCustomerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("[action]/{customerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> DeleteCustomer(int customerId)
        {
            var command = new DeleteCustomerCommand { CustomerId = customerId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}