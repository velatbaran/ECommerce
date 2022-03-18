using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Bussiness.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        IQueryable<Product> ListQuryable(Expression<Func<Product, bool>> filter = null);
        Product GetById(int id);
        Product GetOne(Expression<Func<Product, bool>> filter = null);
        int Create(Product entity);
        int Update(Product entity);
        int Delete(Product entity);
        List<Product> GetProductsByCategory(string category);
        int GetCountByCategory(string category);
        Product GetProductDetail(int id);
        Product GetCategoriesWithProductId(int id);
        int Create(Product entity, int[] categorieIds);
        int Update(Product entity, int[] categorieIds);
    }
}
