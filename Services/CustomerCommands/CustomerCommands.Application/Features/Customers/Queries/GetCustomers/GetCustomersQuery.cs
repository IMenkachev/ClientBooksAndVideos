using MediatR;

namespace CustomerCommands.Application.Features.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<List<CustomerDto>>
    {
        public GetCustomersQuery() { }
    }
}
