using CratiaApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CratiaApp.DataAccess.UnitOfWork
{
    public interface IUnitOfWork<out TContext> : IDisposable
       where TContext : DbContext
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void LoadCollection<TEntity>(TEntity entity, string navigationProperty)
            where TEntity : class;

        void LoadCollection<TEntity, TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> navigationProperty)
            where TElement : class
            where TEntity : class;

        void LoadReference<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty)
            where TProperty : class
            where TEntity : class;

        void LoadReference<TEntity, TProperty>(TEntity entity, string navigationProperty)
            where TProperty : class
            where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
