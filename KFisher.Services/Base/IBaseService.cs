using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KFisher.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> Find(Expression<Func<T, bool>> match);

        Task<bool> Any(Expression<Func<T, bool>> match);

        Task<T> Add(T model);

        Task<IEnumerable<T>> GetAll(int page, int pageSize);
    }
}
