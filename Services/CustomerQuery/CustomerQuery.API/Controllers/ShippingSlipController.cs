using CustomerQuery.API.Features.Queries.ShippingSlips.GetShippingSlip;
using CustomerQuery.API.Features.Queries.ShippingSlips.GetShippingSlips;
using CustomerQuery.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerQuery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingSlipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShippingSlipController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ShippingSlipDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ShippingSlipDto>>> GetAll()
        {
            var query = new GetShippingSlipsQuery();
            var shippingSlips = await _mediator.Send(query);
            return Ok(shippingSlips);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(ShippingSlipDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShippingSlipDto>> GetById(Guid id)
        {
            var query = new GetShippingSlipQuery(id);
            var shippingSlip = await _mediator.Send(query);
            return Ok(shippingSlip);
        }
    }
}
