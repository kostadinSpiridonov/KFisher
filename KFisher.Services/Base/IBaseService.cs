using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KFisher.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> Find(Expression<Func<T, bool>> match);
    }
}
