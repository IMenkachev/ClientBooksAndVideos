using CustomerQuery.API.Features.Customers.Common;
using MediatR;

namespace CustomerQuery.API.Features.Customers.Queries.GetCustomerByLastName
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
