using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CratiaApp.DataAccess.Repositories
{
    public class GenericRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        private readonly TDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(bool withNoTracking = false) => withNoTracking ? _dbSet.AsNoTracking() : _dbSet;

        public IQueryable<TEntity> GetAllIncluding(params string[] includePaths)
        {
            return GetAllIncluding(includePaths, null, false);
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] expressionIncludes)
        {
            return GetAllIncluding(null, expressionIncludes, false);
        }

        public IQueryable<TEntity> GetAllIncluding(string[] includePaths, Expression<Func<TEntity, object>>[] expressionIncludes, bool withNoTracking = false)
        {
            includePaths = includePaths ?? new string[0];
            expressionIncludes = expressionIncludes ?? new Expression<Func<TEntity, object>>[0];

            IQueryable<TEntity> query = GetAll(withNoTracking);

            foreach (var includePath in includePaths)
            {
                query = query.Include(includePath);
            }

            foreach (var expressionInclude in expressionIncludes)
            {
                query = query.Include(expressionInclude);
            }

            return query;
        }


        public void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
