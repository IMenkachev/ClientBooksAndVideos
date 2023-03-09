using AutoMapper;
using CustomerCommands.Application.Features.Commands.Customers.AddCustomer;
using CustomerCommands.Application.Features.Commands.Customers.UpdateCustomer;
using CustomerCommands.Application.Models;
using CustomerCommands.Application.Models.Orders;
using CustomerCommands.Domain.Customers;
using CustomerCommands.Domain.Orders;
using CustomerCommands.Domain.ShippingSlips;
using EventBus.Messages.IntegrationEvents;

namespace CustomerCommands.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, AddCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Order, OrderVm>().ReverseMap();
            CreateMap<OrderItem, OrderItemVm>().ReverseMap();

            // integration events
            CreateMap<Customer, CustomerUpdatedIntegrationEvent>().ReverseMap();
            CreateMap<Customer, CustomerAddedIntegrationEvent>().ReverseMap();
            CreateMap<Customer, CustomerDeletedIntegrationEvent>().ReverseMap();
            CreateMap<Order, OrderCreatedIntegrationEvent>().ReverseMap();
            CreateMap<OrderItem, OrderedItemsIntegrationEvent>().ReverseMap();
            CreateMap<ShippingSlip, ShippingSlipCreatedIntegrationEvent>().ReverseMap();
            CreateMap<Customer, DataSyncIntegrationEvent>().ReverseMap();
        }
    }
}
