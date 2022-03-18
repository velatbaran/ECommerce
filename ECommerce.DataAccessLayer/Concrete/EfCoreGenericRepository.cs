using ECommerce.DataAccessLayer.Abstract;
using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Concrete
{
    public class EfCoreGenericRepository<T> : RepositoryBase, IRepository<T> where T : class
    {
        public DbSet<T> _dbSet;
        public EfCoreGenericRepository()
        {
            _dbSet = db.Set<T>();
        }
        public virtual int Create(T entity)
        {
            _dbSet.Add(entity);
            return Save();
        }

        public virtual int Delete(T entity)
        {
            _dbSet.Update(entity);
            return Save();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual T GetOne(Expression<Func<T, bool>> filter = null)
        {
            return _dbSet.Where(filter).FirstOrDefault();
        }

        public virtual IQueryable<T> ListQuryable(Expression<Func<T, bool>> filter = null)
        {
            return _dbSet.AsQueryable<T>();
        }

        public virtual int Save()
        {
            return db.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            _dbSet.Update(entity);
            return Save();
        }
    }
}
