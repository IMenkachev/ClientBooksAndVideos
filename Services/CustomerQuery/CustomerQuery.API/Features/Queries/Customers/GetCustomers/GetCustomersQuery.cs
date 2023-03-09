using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Customer.GetCustomers
{
    public class GetCustomersQuery : IRequest<List<CustomerDto>>
    {
        public GetCustomersQuery() { }
    }
}
