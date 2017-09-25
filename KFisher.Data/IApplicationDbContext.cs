using KFisher.Entities;
using System.Data.Entity;

namespace KFisher.Data
{
    public interface IApplicationDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<T> Set<T>() where T : class;
    }
}
