using AutoMapper;
using CustomerQuery.API.Entities;
using CustomerQuery.API.Features.Customers.Common;

namespace CustomerQuery.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
