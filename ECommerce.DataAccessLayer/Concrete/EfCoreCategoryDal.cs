using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.DatabaseContext;
using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Concrete
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category>, ICategoryDal
    {
        private readonly DataContext _context = new DataContext();

        public void DeleteProductFromCategory(int categoryId, int productId)
        {
            var query = @"Delete from ProductsAndCategories where CategoryId=@p0 and ProductId=@p1";
            _context.Database.ExecuteSqlRaw(query,categoryId,productId);
        }

        public Category GetCategoryWithProducts(int id)
        {
            return _context.Categories
                                    .Where(x => x.Id == id)
                                    .Include(x => x.ProductsAndCategories)
                                    .ThenInclude(x => x.Product)
                                    .FirstOrDefault();
        }
    }
}
