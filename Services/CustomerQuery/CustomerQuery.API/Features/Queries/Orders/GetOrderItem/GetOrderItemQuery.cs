using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Orders.GetOrderItem
{
    public class GetOrderItemQuery : IRequest<OrderItemDto>
    {
        public GetOrderItemQuery(Guid itemId) 
        {
            ItemId = itemId;
        }

        public Guid ItemId { get; set; }
    }
}
