using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Paradiso.Infrastructure.Data;
using System.Data.Entity.Validation;
using Arash.Infrastructure.Data;

namespace Arash.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IDbContext _Context;
        protected IDbSet<T> _DbSet;

        public Repository(IDbContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<T>();
        }

        public T NewEntityInstance()
        {
            return _DbSet.Create();
        }

        public void Add(T entity)
        {
            _DbSet.Add(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _DbSet.AsQueryable();
        }

        public void Remove(T entity)
        {
            _DbSet.Remove(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _DbSet.FirstOrDefault(predicate);
        }

        public int GetCount(Func<T, bool> predicate)
        {
            return _DbSet.Count(predicate);
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate, int start, int count)
        {
            return _DbSet.Where(predicate).Skip(start).Take(count);
        }

        public void Save()
        {
            try
            {
                _Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var s = e.EntityValidationErrors.ToList();
                throw;
            }
        }

        public IEnumerable<K> GetQuery<K>(string queryString, Func<K, bool> predicate = null) where K : class
        {
            if (predicate != null)
                return _Context.Db.SqlQuery<K>(queryString).Where(predicate);
            return _Context.Db.SqlQuery<K>(queryString);

        }
    }
}