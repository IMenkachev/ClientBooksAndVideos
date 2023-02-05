using AutoMapper;
using CustomerQuery.API.Features.Customers.Common;
using CustomerQuery.API.Repositories;
using MediatR;

namespace CustomerQuery.API.Features.Customers.Queries.GetCustomerByFirstName
{
    public class GetCustomerByFirstNameQueryHandler : IRequestHandler<GetCustomerByFirstNameQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByFirstNameQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<CustomerDto>> Handle(GetCustomerByFirstNameQuery request, CancellationToken cancellationToken)
        {
            var customersByFirstName = await _customerRepository.GetCustomerByFirstName(request.FirstName);
            return _mapper.Map<List<CustomerDto>>(customersByFirstName);
        }
    }
}
