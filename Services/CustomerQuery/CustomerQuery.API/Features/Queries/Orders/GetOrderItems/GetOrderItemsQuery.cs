using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Orders.GetOrderItems
{
    public class GetOrderItemsQuery : IRequest<List<OrderItemDto>>
    {
        public GetOrderItemsQuery() { }
    }
}
