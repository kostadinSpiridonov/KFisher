using KFIsher.Mobile.Services.Models;
using System;
using System.Threading.Tasks;

namespace KFIsher.Mobile.Services.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UserModel> Register(UserRegisterModel model);

        /// <summary>
        /// Return user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserModel> GetById(Guid userId);
    }
}
