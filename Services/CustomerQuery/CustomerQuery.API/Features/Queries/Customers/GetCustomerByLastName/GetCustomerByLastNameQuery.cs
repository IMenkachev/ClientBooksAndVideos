using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Customer.GetCustomerByLastName
{
    public class GetCustomerByLastNameQuery : IRequest<List<CustomerDto>>
    {
        public string LastName { get; set; }
        public GetCustomerByLastNameQuery(string lastName)
        {
            LastName = lastName;
        }
    }
}
