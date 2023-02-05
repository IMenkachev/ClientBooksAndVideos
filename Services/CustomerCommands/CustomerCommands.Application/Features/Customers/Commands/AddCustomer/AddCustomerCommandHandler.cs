using AutoMapper;
using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCommands.Application.Features.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddCustomerCommandHandler> _logger;

        public AddCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<AddCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
             
            var newCustomer = _mapper.Map<Customer>(request.Customer);
            await _customerRepository.AddAsync(newCustomer);

            _logger.LogInformation($"Customer {newCustomer.Id} is successfully created.");

            return newCustomer.Id;
        }
    }
}
