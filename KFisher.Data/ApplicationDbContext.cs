using System.Data.Entity;
using KFisher.Entities;

namespace KFisher.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public IDbSet<User> Users { get; set; }

        // TODO: move the default connection name
        public ApplicationDbContext()
            : base("KFisherConnection")
        {
            this.Configure();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        private void Configure()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
