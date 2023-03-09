using AutoMapper;
using CustomerCommands.Domain.Customers;
using EventBus.Messages.IntegrationEvents;

namespace CustomerCommand.API.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerUpdatedIntegrationEvent>().ReverseMap();
        }
    }
}
