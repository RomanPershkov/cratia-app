using CratiaApp.DataAccess.Context;
using CratiaApp.DataAccess.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CratiaApp.DataAccess.UnitOfWork
{
    public class CratiaAppUnitOfWork : ICratiaAppUnitOfWork
    {
        private readonly Hashtable _repositories;

        private readonly CratiaAppDbContext _context;

        public CratiaAppUnitOfWork() : this(new CratiaAppDbContext()) { }

        public CratiaAppUnitOfWork(CratiaAppDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            var entityTypeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(entityTypeName))
            {
                var repositoryInstance = new GenericRepository<TEntity, CratiaAppDbContext>(_context);

                _repositories.Add(entityTypeName, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[entityTypeName];
        }

        public void LoadCollection<TEntity>(TEntity entity, string navigationProperty) where TEntity : class
        {
            _context.Entry(entity).Collection(navigationProperty).Load();
        }

        public void LoadCollection<TEntity, TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> navigationProperty)
            where TEntity : class
            where TElement : class
        {
            _context.Entry(entity).Collection(navigationProperty).Load();
        }

        public void LoadReference<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty)
            where TEntity : class
            where TProperty : class
        {
            _context.Entry(entity).Reference(navigationProperty).Load();
        }

        public void LoadReference<TEntity, TProperty>(TEntity entity, string navigationProperty)
            where TEntity : class
            where TProperty : class
        {
            _context.Entry(entity).Reference<TProperty>(navigationProperty).Load();
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (OptimisticConcurrencyException)
            {
                return 0;
            }
        }
        
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_context != null)
                    _context.Dispose();
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        
    }
}
