using CustomerCommands.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCommands.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customerToDelete == null) 
            { 
                throw new ArgumentNullException(nameof(customerToDelete));
            }

            await _customerRepository.DeleteAsync(customerToDelete);

            _logger.LogInformation($"Customer {customerToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
