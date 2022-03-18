using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class ProductAndCategory
    {
        public int CategoryId { get; set; }   // Primary key
        public virtual Category Category { get; set; }

        public int ProductId { get; set; }  // Primary key
        public virtual Product Product { get; set; }
    }
}
