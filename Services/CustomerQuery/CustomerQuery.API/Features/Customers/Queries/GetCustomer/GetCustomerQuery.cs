using CustomerQuery.API.Features.Customers.Common;
using MediatR;

namespace CustomerQuery.API.Features.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerDto>
    {
        public int CustomerId { get; set; }
        public GetCustomerQuery(int customerId) 
        {
            CustomerId = customerId;    
        }
    }
}
