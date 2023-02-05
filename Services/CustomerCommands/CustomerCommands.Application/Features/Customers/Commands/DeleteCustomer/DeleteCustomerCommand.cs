using CustomerCommands.Domain.Entities;
using MediatR;

namespace CustomerCommands.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
    }
}
