using AutoMapper;
using FoodSys.Application.DTO.Request.Customer;
using FoodSys.Application.DTO.Response.Customer;
using FoodSys.Domain.Entity;

namespace FoodSys.Application.Map
{
    public class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile() 
        { 
            CreateMap<Customer, AddCustomerRequest>().ReverseMap();
            CreateMap<Customer, AddCustomerResponse>().ReverseMap();
            CreateMap<Customer, UpdateCustomerRequest>().ReverseMap();
            CreateMap<Customer, UpdateCustomerResponse>().ReverseMap();
            CreateMap<Customer, GetCustomerResponse>().ReverseMap();
        }
    }
}
