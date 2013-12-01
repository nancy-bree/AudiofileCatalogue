using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;

namespace CI.DAL
{
    public class Repository<T> where T : class
    {
        internal CIContext _context;
        internal DbSet<T> _dbSet;

        public Repository(CIContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public virtual T GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> Get(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual void Insert(T obj)
        {
            _dbSet.Add(obj);
        }

        public virtual void Update(T obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T obj = _dbSet.Find(id);
            Delete(obj);
        }

        public virtual void Delete(T obj)
        {
            if (_context.Entry(obj).State == EntityState.Detached)
            {
                _dbSet.Attach(obj);
            }
            _dbSet.Remove(obj);
        }
    }
}