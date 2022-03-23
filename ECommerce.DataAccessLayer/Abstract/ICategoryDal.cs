using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        Category GetCategoryWithProducts(int id);
        void DeleteProductFromCategory(int categoryId, int productId);
    }
}
