using CustomerQuery.API.Features.Queries.Membership.GetMembership;
using CustomerQuery.API.Features.Queries.Membership.GetMemberships;
using CustomerQuery.API.Features.Queries.Orders.GetOrderItem;
using CustomerQuery.API.Features.Queries.Orders.GetOrderItems;
using CustomerQuery.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerQuery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var query = new GetOrdersQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderDto>> GetById(Guid id)
        {
            var query = new GetOrderQuery(id);
            var order = await _mediator.Send(query);
            return Ok(order);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<OrderItemDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAllOrderItems()
        {
            var query = new GetOrderItemsQuery();
            var orderItems = await _mediator.Send(query);
            return Ok(orderItems);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(OrderItemDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderItemDto>> GetOrderItemById(Guid id)
        {
            var query = new GetOrderItemQuery(id);
            var orderItem = await _mediator.Send(query);
            return Ok(orderItem);
        }
    }
}
