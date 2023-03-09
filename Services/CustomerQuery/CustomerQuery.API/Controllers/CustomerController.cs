using CustomerQuery.API.Features.Queries.Customer.GetCustomer;
using CustomerQuery.API.Features.Queries.Customer.GetCustomerByFirstName;
using CustomerQuery.API.Features.Queries.Customer.GetCustomerByLastName;
using CustomerQuery.API.Features.Queries.Customer.GetCustomers;
using CustomerQuery.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerQuery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            var query = new GetCustomersQuery();
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CustomerDto>> GetById(Guid id)
        {
            var query = new GetCustomerQuery(id);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }

        [HttpGet("[action]/{firstName}")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetByFirstName(string firstName)
        {
            var query = new GetCustomerByFirstNameQuery(firstName);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }

        [HttpGet("[action]/{lastName}")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetByLastName(string lastName)
        {
            var query = new GetCustomerByLastNameQuery(lastName);
            var customer = await _mediator.Send(query);
            return Ok(customer);
        }
    }
}
