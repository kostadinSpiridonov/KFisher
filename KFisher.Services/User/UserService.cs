using KFisher.Data;
using KFisher.Entities;

namespace KFisher.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IApplicationDbContext context)
            : base(context)
        {

        }
    }
}
