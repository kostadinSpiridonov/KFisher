using KFisher.Data;
using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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

        public Task<T> Add(T model)
        {
            var entity = this.dbSet.Add(model);
            this.context.SaveChangesAsync();

            return Task.FromResult(entity);
        }

        public Task<bool> Any(Expression<Func<T, bool>> match)
        {
            return this.dbSet.AnyAsync(match);
        }

        public Task<T> Find(Expression<Func<T, bool>> match)
        {
            return this.dbSet.SingleOrDefaultAsync(match);
        }

        public Task<IEnumerable<T>> GetAll(int page, int pageSize)
        {
            var result = this.dbSet
                  .AsNoTracking()
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .ToArray();

            return Task.FromResult<IEnumerable<T>>(result);
        }
    }
}
