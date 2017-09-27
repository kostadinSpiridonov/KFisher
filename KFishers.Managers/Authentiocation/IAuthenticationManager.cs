using KFisher.Library.DTOs;
using System.Threading.Tasks;

namespace KFishers.Managers
{
    public interface IAuthenticationManager
    {
        Task<UserDto> FindUser(string email, string password);
    }
}
