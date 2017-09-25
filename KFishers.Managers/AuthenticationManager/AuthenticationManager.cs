using System.Threading.Tasks;
using KFisher.Library.DTOs;
using KFisher.Services;

namespace KFishers.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationManager(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public Task<UserDto> FindUser(string email, string password)
        {
            return this.authenticationService.Find(x => x.Email == email && x.Password == password)
                //TODO: set up automapper
                .ContinueWith(x => new UserDto());
        }
    }
}
