using AutoMapper;
using CustomerCommands.Application.Contracts.Persistence;
using EventBus.Messages.IntegrationEvents;
using MassTransit;
using MediatR;
using System.Text;

namespace CustomerCommands.Application.Features.Queries.SyncData
{
    public class SyncDataQueryHandler : IRequestHandler<DataSyncQuery, string>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public SyncDataQueryHandler(IUnitOfWork uow, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task<string> Handle(DataSyncQuery request, CancellationToken cancellationToken)
        {
            var customers = await _uow.Customers.GetAll();
            var memberships = await _uow.Memberships.GetAll();
            var products = await _uow.Products.GetAll();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Customers:");

            foreach (var item in customers)
            {
                sb.AppendLine(item.FirstName.ToString() + " " + item.LastName.ToString());
            }

            sb.AppendLine();
            sb.AppendLine("Memberships:");
            foreach (var item in memberships)
            {
                sb.AppendLine(item.Name.ToString());
            }

            sb.AppendLine();
            sb.AppendLine("Products:");
            foreach (var item in products)
            {
                sb.AppendLine(item.Name.ToString());
            }

            string mergedList = sb.ToString();

            var customer = customers.FirstOrDefault();
            var eventMessage = _mapper.Map<DataSyncIntegrationEvent>(customer);
            await _publishEndpoint.Publish(eventMessage);

            return mergedList;
        }
    }
}
