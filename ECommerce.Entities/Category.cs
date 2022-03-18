using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class Category : BaseEntity
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage ="{0} alanı boş geçilemez."),StringLength(50,ErrorMessage ="{0} alanı en fazla {1} karakter olmalıdır.")]
        public string Name { get; set; }

        public virtual List<ProductAndCategory> ProductsAndCategories { get; set; }
        public Category()
        {
            ProductsAndCategories = new List<ProductAndCategory>();
        }
    }
}
