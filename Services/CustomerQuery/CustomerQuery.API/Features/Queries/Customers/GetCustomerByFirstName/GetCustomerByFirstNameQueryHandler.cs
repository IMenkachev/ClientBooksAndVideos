using AutoMapper;
using CustomerQuery.API.Contracts;
using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Customer.GetCustomerByFirstName
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
