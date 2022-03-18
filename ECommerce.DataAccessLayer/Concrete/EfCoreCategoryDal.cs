using ECommerce.DataAccessLayer.Abstract;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Concrete
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category>,ICategoryDal
    {
    }
}
