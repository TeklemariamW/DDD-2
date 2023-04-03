using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
