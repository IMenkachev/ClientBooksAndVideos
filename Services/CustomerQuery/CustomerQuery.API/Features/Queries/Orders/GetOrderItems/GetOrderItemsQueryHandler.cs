using AutoMapper;
using CustomerQuery.API.Contracts;
using CustomerQuery.API.Models;
using MediatR;

namespace CustomerQuery.API.Features.Queries.Orders.GetOrderItems
{
    public class GetOrderItemsQueryHandler : IRequestHandler<GetOrderItemsQuery, List<OrderItemDto>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public GetOrderItemsQueryHandler(IOrderItemRepository orderRepository, IMapper mapper)
        {
            _orderItemRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrderItemDto>> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            return _mapper.Map<List<OrderItemDto>>(orderItems);
        }
    }
}
