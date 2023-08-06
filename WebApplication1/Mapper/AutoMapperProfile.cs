using AutoMapper;
using JourneyNavigation.Domain.Dtos;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }

}
