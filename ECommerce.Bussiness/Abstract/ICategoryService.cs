using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Bussiness.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        IQueryable<Category> ListQuryable(Expression<Func<Category, bool>> filter = null);
        Category GetById(int id);
        Category GetOne(Expression<Func<Category, bool>> filter = null);
        int Create(Category entity);
        int Update(Category entity);
        int Delete(Category entity);
    }
}
