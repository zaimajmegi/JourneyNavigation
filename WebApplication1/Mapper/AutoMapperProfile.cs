using AutoMapper;
using TaskManagement.API.Dtos;
using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }

}
