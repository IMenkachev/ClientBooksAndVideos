using CustomerQuery.API.Features.Customers.Common;
using CustomerQuery.API.Features.Customers.Queries.GetCustomer;
using CustomerQuery.API.Features.Customers.Queries.GetCustomerByFirstName;
using CustomerQuery.API.Features.Customers.Queries.GetCustomerByLastName;
using CustomerQuery.API.Features.Customers.Queries.GetCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerQuery.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomerQueriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerQueriesController(IMediator mediator)
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

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var query = new GetCustomerQuery(id);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }

        [HttpGet("[action]/{firstName}")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomerByFirstName(string firstName)
        {
            var query = new GetCustomerByFirstNameQuery(firstName);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomerByLastName(string lastName)
        {
            var query = new GetCustomerByLastNameQuery(lastName);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }
    }
}
