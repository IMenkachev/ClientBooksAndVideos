using AutoMapper;
using CustomerCommands.Application.Contracts.Persistence;
using CustomerCommands.Domain.Customers;
using EventBus.Messages.IntegrationEvents;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerCommands.Application.Features.Commands.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public UpdateCustomerCommandHandler(IUnitOfWork uow, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToUpdate = await _uow.Customers.GetByIdAsync(request.Id);
            if (customerToUpdate == null)
            {
                throw new ArgumentNullException(nameof(customerToUpdate));
            }

            customerToUpdate.UpdateCustomer(
                request.Id,
                request.FirstName,
                request.LastName);

            _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(Customer));

            await _uow.Customers.SaveAsync(customerToUpdate);

            var eventMessage = _mapper.Map<CustomerUpdatedIntegrationEvent>(customerToUpdate);
            await _publishEndpoint.Publish(eventMessage);

            _logger.LogInformation($"Customer {customerToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
