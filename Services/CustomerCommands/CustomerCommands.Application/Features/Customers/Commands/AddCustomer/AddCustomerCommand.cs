using CustomerCommands.Domain.Entities;
using MediatR;

namespace CustomerCommands.Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerCommand : IRequest<int>
    {
        public Customer Customer { get; set; }
    }
}
