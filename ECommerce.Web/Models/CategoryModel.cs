using ECommerce.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class CategoryModel : BaseModel
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olmalıdır.")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
