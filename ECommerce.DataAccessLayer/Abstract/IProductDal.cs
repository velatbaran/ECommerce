using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<Product> GetProductsByCategory(string category);
        int GetCountByCategory(string category);
        Product GetProductDetail(int id);
        Product GetCategoriesWithProductId(int id);
        int Create(Product entity,int[] categorieIds);
        int Update(Product entity,int[] categorieIds);
    }
}
