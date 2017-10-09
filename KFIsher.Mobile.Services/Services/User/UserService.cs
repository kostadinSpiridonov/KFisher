using System.Threading.Tasks;
using KFIsher.Mobile.Services.Connection;
using KFIsher.Mobile.Services.Models;
using KFIsher.Mobile.Services.Helpers;
using KFisher.Mobile.Database.Services;
using System;

namespace KFIsher.Mobile.Services.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IAuthenticationServiceLS authenticationServiceLS;

        public UserService(
            IHttpConnection httpConnection,
            IAuthenticationServiceLS authenticationServiceLS)
            : base(httpConnection)
        {
            this.authenticationServiceLS = authenticationServiceLS;
        }

        /// <summary>
        /// Return user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserModel> GetById(Guid userId)
        {
            var token = this.authenticationServiceLS.GetToken();

            var response = await this.GetRequestAsync($"{ServiceDefinitions.GetUserById}{userId}", token);
            if (response.HasResult && response.ResponseMessage.IsSuccessStatusCode)
            {
                return await JsonHelper.Serialize<UserModel>(response);
            }

            return default(UserModel);
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UserModel> Register(UserRegisterModel model)
        {
            var response = await this.PostRequestAsync(ServiceDefinitions.RegisterUser, model);
            if (response.HasResult && response.ResponseMessage.IsSuccessStatusCode)
            {
                return await JsonHelper.Serialize<UserModel>(response);
            }

            return default(UserModel);
        }
    }
}
