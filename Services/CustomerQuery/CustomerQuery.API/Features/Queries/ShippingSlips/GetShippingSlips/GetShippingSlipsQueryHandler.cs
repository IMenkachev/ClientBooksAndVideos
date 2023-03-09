using AutoMapper;
using CustomerQuery.API.Contracts;
using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.ShippingSlips.GetShippingSlips
{
    public class GetShippingSlipsQueryHandler : IRequestHandler<GetShippingSlipsQuery, List<ShippingSlipDto>>
    {
        private readonly IShippingSlipRepository _shippingSlipRepository;
        private readonly IMapper _mapper;

        public GetShippingSlipsQueryHandler(IShippingSlipRepository shippingSlipRepository, IMapper mapper)
        {
            _shippingSlipRepository = shippingSlipRepository ?? throw new ArgumentNullException(nameof(shippingSlipRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ShippingSlipDto>> Handle(GetShippingSlipsQuery request, CancellationToken cancellationToken)
        {
            var shippingSlips = await _shippingSlipRepository.GetAllAsync();
            return _mapper.Map<List<ShippingSlipDto>>(shippingSlips);
        }
    }
}
