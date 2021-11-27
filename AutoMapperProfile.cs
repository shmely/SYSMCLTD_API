using AutoMapper;
using SYSMCLTD_API.DTOS;
using SYSMCLTD_API.Models;

namespace SYSMCLTD_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
