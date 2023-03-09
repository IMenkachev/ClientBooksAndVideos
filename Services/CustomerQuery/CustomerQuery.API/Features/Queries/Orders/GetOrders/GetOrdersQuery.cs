using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Membership.GetMemberships
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
        public GetOrdersQuery() { }
    }
}
