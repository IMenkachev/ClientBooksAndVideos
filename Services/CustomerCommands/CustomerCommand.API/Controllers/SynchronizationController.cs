using CustomerCommands.Application.Features.Queries.SyncData;
using CustomerCommands.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerCommand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SynchronizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SynchronizationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> SyncData()
        {
            var query = new DataSyncQuery();
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }
    }
}
