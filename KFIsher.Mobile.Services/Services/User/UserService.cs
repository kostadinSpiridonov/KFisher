using KFIsher.Mobile.Services.Connection;

namespace KFIsher.Mobile.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpConnection httpConnection;

        public UserService(IHttpConnection httpConnection)
        {
            this.httpConnection = httpConnection;
        }
    }
}
