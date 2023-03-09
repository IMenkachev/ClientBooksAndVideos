using CustomerCommands.Domain.Customers;
using MediatR;

namespace CustomerCommands.Application.Features.Commands.Customers.AddCustomer
{
    public class AddCustomerCommand : IRequest<Guid>
    {
        public Customer Customer { get; set; }
    }
}
