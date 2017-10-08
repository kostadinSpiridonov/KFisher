using KFisher.Data;
using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KFisher.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IDbSet<T> dbSet;

        protected readonly IApplicationDbContext context;

        public BaseService(IApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public Task<bool> Any(Expression<Func<T, bool>> match)
        {
            return this.dbSet.AnyAsync(match);
        }

        public Task<T> Find(Expression<Func<T, bool>> match)
        {
            return this.dbSet.SingleOrDefaultAsync(match);
        }
    }
}
