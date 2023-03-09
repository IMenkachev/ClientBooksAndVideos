using AutoMapper;
using DatabaseSynchronization.Models;
using EventBus.Messages.IntegrationEvents;

namespace DatabaseSynchronization.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto, CustomerUpdatedIntegrationEvent>().ReverseMap();
            CreateMap<CustomerDto, CustomerAddedIntegrationEvent>().ReverseMap();
            CreateMap<CustomerDto, CustomerDeletedIntegrationEvent>().ReverseMap();
            CreateMap<CustomerDto, DataSyncIntegrationEvent>().ReverseMap();
            CreateMap<OrderDto, OrderCreatedIntegrationEvent>().ReverseMap();
            CreateMap<OrderItemDto, OrderedItemsIntegrationEvent>().ReverseMap();
            CreateMap<ShippingSlipDto, ShippingSlipCreatedIntegrationEvent>().ReverseMap();
        }
    }
}
