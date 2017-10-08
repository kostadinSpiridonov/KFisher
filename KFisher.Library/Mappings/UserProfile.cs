using AutoMapper;
using KFisher.Entities;
using KFisher.Library.DTOs;
using KFisher.WebApi.Models.InputModels;

namespace KFisher.Library.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserModel, UserDto>();
        }
    }
}
