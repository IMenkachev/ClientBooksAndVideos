using AutoMapper;
using CustomerCommands.Application.Contracts.Persistence;
using EventBus.Messages.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCommands.Application.Features.Commands.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public DeleteCustomerCommandHandler(IUnitOfWork uow, ILogger<DeleteCustomerCommandHandler> logger, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _uow.Customers.GetByIdAsync(request.CustomerId);
            if (customerToDelete == null)
            {
                throw new ArgumentNullException(nameof(customerToDelete));
            }

            await _uow.Customers.DeleteAsync(customerToDelete);

            var eventMessage = _mapper.Map<CustomerDeletedIntegrationEvent>(customerToDelete);
            await _publishEndpoint.Publish(eventMessage);

            _logger.LogInformation($"Customer {customerToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
