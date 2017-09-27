using KFisher.Data;
using KFisher.Entities;

namespace KFisher.Services
{
    public class AuthenticationService : BaseService<User>, IAuthenticationService
    {
        public AuthenticationService(IApplicationDbContext context)
            : base(context)
        {

        }
    }
}