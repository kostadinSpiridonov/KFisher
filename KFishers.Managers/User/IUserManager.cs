using KFisher.Library.DTOs;
using System.Threading.Tasks;

namespace KFishers.Managers
{
    public interface IUserManager
    {
        Task<UserDto> Add(UserDto user);
    }
}
