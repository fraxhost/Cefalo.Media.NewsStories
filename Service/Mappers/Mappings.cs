using AutoMapper;
using DB.Models;
using Service.DTOs;
using Service.DTOs.Story;

namespace Service.Mappers
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Story, CreateStoryDto>().ReverseMap();
            CreateMap<Story, UpdateStoryDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}