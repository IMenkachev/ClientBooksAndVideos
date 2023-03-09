using AutoMapper;
using CustomerQuery.API.Contracts;
using CustomerQuery.API.Models;
using MassTransit;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Customer.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            //var customer = customers.FirstOrDefault();
            //var eventMessage = _mapper.Map<GetCustomersIntegrationEvent>(customer);
            //await _publishEndpoint.Publish(eventMessage);

            return _mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
