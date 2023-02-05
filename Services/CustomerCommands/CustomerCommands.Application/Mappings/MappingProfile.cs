using AutoMapper;
using CustomerCommands.Application.Features.Customers.Commands.AddCustomer;
using CustomerCommands.Application.Features.Customers.Commands.UpdateCustomer;
using CustomerCommands.Application.Features.Customers.Queries.GetCustomers;
using CustomerCommands.Domain.Entities;

namespace CustomerCommands.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, AddCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
