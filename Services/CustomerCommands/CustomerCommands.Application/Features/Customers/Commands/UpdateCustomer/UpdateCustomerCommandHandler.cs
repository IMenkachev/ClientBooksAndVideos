using AutoMapper;
using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCommands.Application.Features.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.Id);
            if (customerToUpdate == null)
            {
                throw new ArgumentNullException(nameof(customerToUpdate));
            }

            customerToUpdate.UpdateCustomer(request.Id, request.UserName, request.FirstName, request.LastName, request.Age, request.Address, request.EmailAddress, request.Country, request.City);
            _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));

            await _customerRepository.SaveAsync(customerToUpdate);

            _logger.LogInformation($"Customer {customerToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
