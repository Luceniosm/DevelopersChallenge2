using System;
using System.Linq;
using System.Linq.Expressions;
using Aplicacao.Domain.Interface.Repository;
using Aplicacao.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Infra.Data.Repository._Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ExtractContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ExtractContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            var dbSet = DbSet.Add(obj);
            return dbSet.Entity;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IQueryable<TEntity> FindNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual TEntity Update(TEntity obj)
        {
            Db.ChangeTracker.AutoDetectChangesEnabled = false;
            var dbset = DbSet.Update(obj);
            return dbset.Entity;
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
