//using AutoMapper;
//using CustomerQuery.API.Contracts;
//using CustomerQuery.API.Features.Models;
//using MediatR;

//namespace CustomerQuery.API.Features.Queries.ShippingSlips.GetShippingSlip
//{
//    public class GetShippingSlipQueryHandler : IRequestHandler<GetShippingSlipQuery, ShippingSlipDto>
//    {
//        private readonly IShippingSlipRepository _shippingSlipRepository;
//        private readonly IMapper _mapper;

//        public GetShippingSlipQueryHandler(IShippingSlipRepository shippingSlipRepository, IMapper mapper)
//        {
//            _shippingSlipRepository = shippingSlipRepository ?? throw new ArgumentNullException(nameof(shippingSlipRepository));
//            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//        }

//        public async Task<ShippingSlipDto> Handle(GetShippingSlipQuery request, CancellationToken cancellationToken)
//        {
//            var shippingSlip = await _shippingSlipRepository.GetByIdAsync(request.ShippingSlipId);
//            return _mapper.Map<ShippingSlipDto>(shippingSlip);
//        }
//    }
//}
