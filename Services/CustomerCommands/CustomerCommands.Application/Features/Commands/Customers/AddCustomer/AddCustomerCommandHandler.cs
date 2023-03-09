using AutoMapper;
using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Customers;
using EventBus.Messages.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCommands.Application.Features.Commands.Customers.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>

    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<AddCustomerCommandHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public AddCustomerCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<AddCustomerCommandHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = _mapper.Map<Customer>(request.Customer);
            await _uow.Customers.AddAsync(newCustomer);

            var eventMessage = _mapper.Map<CustomerAddedIntegrationEvent>(newCustomer);
            await _publishEndpoint.Publish(eventMessage);

            _logger.LogInformation($"Customer {newCustomer.Id} is successfully created.");

            return newCustomer.Id;
        }
    }
}
