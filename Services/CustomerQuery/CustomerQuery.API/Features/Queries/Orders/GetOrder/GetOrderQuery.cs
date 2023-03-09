using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Membership.GetMembership
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public GetOrderQuery(Guid orderId) 
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
    }
}
