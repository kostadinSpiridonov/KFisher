using System.Threading.Tasks;
using KFisher.Services;
using KFishers.Managers.Security;

namespace KFishers.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IAuthenticationService authenticationService;

        private readonly IHashGenerator hashGenerator;

        public AuthenticationManager(
            IAuthenticationService authenticationService,
            IHashGenerator hashGenerator)
        {
            this.authenticationService = authenticationService;
            this.hashGenerator = hashGenerator;
        }

        public Task<bool> Authenticate(string email, string password)
        {
            string passwordHash = this.hashGenerator.ComputeSHA512Hash(password);
            return this.authenticationService.Any(x => x.Email == email && x.Password == passwordHash);
        }
    }
}
