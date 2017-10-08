using KFisher.Library.DTOs;
using System.Threading.Tasks;

namespace KFishers.Managers
{
    public interface IAuthenticationManager
    {
        Task<bool> Authenticate(string email, string password);
    }
}
