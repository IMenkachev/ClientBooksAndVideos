using Amazon.Runtime.Internal;
using CustomerQuery.API.Features.Customers.Common;
using MediatR;

namespace CustomerQuery.API.Features.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<List<CustomerDto>>
    {
        public GetCustomersQuery() { }
    }
}
