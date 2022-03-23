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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public int Create(Category entity)
        {
            return _categoryDal.Create(entity);
        }

        public int Delete(Category entity)
        {
            return _categoryDal.Delete(entity);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
           return _categoryDal.GetAll(filter);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public Category GetOne(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetOne(filter);
        }

        public Category GetCategoryWithProducts(int id)
        {
            return _categoryDal.GetCategoryWithProducts(id);
        }

        public IQueryable<Category> ListQuryable(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.ListQuryable(filter);
        }

        public int Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }

        public void DeleteProductFromCategory(int categoryId, int productId)
        {
            _categoryDal.DeleteProductFromCategory(categoryId, productId);
        }
    }
}
