using MediatR;

namespace CustomerCommands.Application.Features.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid CustomerId { get; set; }
    }
}
