using ECommerce.Bussiness.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Bussiness.Manager
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public int Create(Product entity)
        {
            return _productDal.Create(entity);
        }

        public int Create(Product entity, int[] categorieIds)
        {
            return _productDal.Create(entity,categorieIds);
        }

        public int Delete(Product entity)
        {
            return _productDal.Delete(entity);
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetAll(filter);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetCategoriesWithProductId(int id)
        {
            return _productDal.GetCategoriesWithProductId(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productDal.GetCountByCategory(category);
        }

        public Product GetOne(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetOne(filter);
        }

        public Product GetProductDetail(int id)
        {
            return _productDal.GetProductDetail(id);
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _productDal.GetProductsByCategory(category);
        }

        public IQueryable<Product> ListQuryable(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.ListQuryable(filter);
        }

        public int Update(Product entity)
        {
            return _productDal.Update(entity);
        }

        public int Update(Product entity, int[] categorieIds)
        {
            return _productDal.Update(entity, categorieIds);
        }
    }
}
