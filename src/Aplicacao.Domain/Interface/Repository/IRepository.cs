using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aplicacao.Domain.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity obj);

        TEntity GetById(Guid id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindNoTracking(Expression<Func<TEntity, bool>> predicate);

        TEntity Update(TEntity obj);

        void Remove(Guid id);

        int SaveChanges();
    }
}
