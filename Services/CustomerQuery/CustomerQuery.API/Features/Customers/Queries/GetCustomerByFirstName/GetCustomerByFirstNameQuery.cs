using CustomerQuery.API.Features.Customers.Common;
using MediatR;

namespace CustomerQuery.API.Features.Customers.Queries.GetCustomerByFirstName
{
    public class GetCustomerByFirstNameQuery : IRequest<List<CustomerDto>>
    {
        public string FirstName { get; set; }
        public GetCustomerByFirstNameQuery(string firstName)
        {
            FirstName = firstName;  
        }
    }
}
