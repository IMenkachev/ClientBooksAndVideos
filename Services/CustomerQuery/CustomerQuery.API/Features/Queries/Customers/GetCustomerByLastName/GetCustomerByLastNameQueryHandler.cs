using AutoMapper;
using CustomerQuery.API.Contracts;
using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Customer.GetCustomerByLastName
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
