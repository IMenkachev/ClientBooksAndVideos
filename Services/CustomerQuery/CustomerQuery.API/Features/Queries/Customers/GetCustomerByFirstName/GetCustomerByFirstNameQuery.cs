using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Customer.GetCustomerByFirstName
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
