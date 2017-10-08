using System;
using System.Threading.Tasks;
using KFisher.Library.DTOs;
using KFisher.Services;
using AutoMapper;
using KFisher.Entities;
using KFishers.Managers.Security;

namespace KFishers.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserService userService;

        private readonly IHashGenerator hashGenerator;

        public UserManager(
            IUserService userService,
            IHashGenerator hashGenerator)
        {
            this.userService = userService;
            this.hashGenerator = hashGenerator;
        }

        public Task<UserDto> Add(UserDto user)
        {
            var mappedModel = Mapper.Map<User>(user);
            mappedModel.Password = hashGenerator.ComputeSHA512Hash(user?.Password);

            return this.userService
                .Add(mappedModel)
                .ContinueWith(x => Mapper.Map<UserDto>(x.Result));
        }
    }
}
