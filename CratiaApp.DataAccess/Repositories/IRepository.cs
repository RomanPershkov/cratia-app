using System;
using System.Linq;
using System.Linq.Expressions;

namespace CratiaApp.DataAccess.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> GetAll(bool withNoTracking = false);

        IQueryable<T> GetAllIncluding(params string[] includePaths);
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] expressionIncludes);
        IQueryable<T> GetAllIncluding(string[] includePaths, Expression<Func<T, object>>[] expressionIncludes, bool withNoTracking = false);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
