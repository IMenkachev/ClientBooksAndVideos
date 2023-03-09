using CustomerQuery.API.Features.Queries.Membership.GetMembership;
using CustomerQuery.API.Features.Queries.Membership.GetMemberships;
using CustomerQuery.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerQuery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembershipController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<MembershipDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MembershipDto>>> GetAll()
        {
            var query = new GetMembershipsQuery();
            var memberships = await _mediator.Send(query);
            return Ok(memberships);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(MembershipDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MembershipDto>> GetById(Guid id)
        {
            var query = new GetMembershipQuery(id);
            var membership = await _mediator.Send(query);
            return Ok(membership);
        }
    }
}
