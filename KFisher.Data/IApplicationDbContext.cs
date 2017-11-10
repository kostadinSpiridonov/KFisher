using KFisher.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KFisher.Data
{
    public interface IApplicationDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Location> Locations { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Story> Stories { get; set; }

        IDbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
