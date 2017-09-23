using AutoMapper;
using KFisher.Entities;
using KFisher.Library.DTOs;

namespace KFisher.Library.Mappings
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
