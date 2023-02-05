using AutoMapper;
using CustomerQuery.API.Features.Customers.Common;
using CustomerQuery.API.Repositories;
using MediatR;

namespace CustomerQuery.API.Features.Customers.Queries.GetCustomerByLastName
{
    public class GetCustomerByLastNameQueryHandler : IRequestHandler<GetCustomerByLastNameQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByLastNameQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CustomerDto>> Handle(GetCustomerByLastNameQuery request, CancellationToken cancellationToken)
        {
            var customersByLastName = await _customerRepository.GetCustomerByLastName(request.LastName);
            return _mapper.Map<List<CustomerDto>>(customersByLastName);
        }
    }
}
