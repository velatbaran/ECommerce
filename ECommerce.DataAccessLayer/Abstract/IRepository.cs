using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        IQueryable<T> ListQuryable(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter = null);
        int Save();
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
