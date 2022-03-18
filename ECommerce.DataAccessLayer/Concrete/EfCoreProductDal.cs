using ECommerce.DataAccessLayer.Abstract;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Concrete
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product>, IProductDal
    {
        public int Create(Product entity, int[] categorieIds)
        {
            throw new NotImplementedException();
        }

        public Product GetCategoriesWithProductId(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCountByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Product GetProductDetail(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public int Update(Product entity, int[] categorieIds)
        {
            throw new NotImplementedException();
        }
    }
}
