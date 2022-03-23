using ECommerce.Entities;
using System.Collections.Generic;

namespace ECommerce.Web.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
