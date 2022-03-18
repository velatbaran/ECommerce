using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class Product : BaseEntity
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Image { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public decimal Price { get; set; }

        [DisplayName("Miktar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public int Amount { get; set; }

        [DisplayName("Stokta Var Mı?")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public bool IsStock { get; set; }

        public virtual List<ProductAndCategory> ProductsAndCategories { get; set; }
        public Product()
        {
            ProductsAndCategories = new List<ProductAndCategory>();
        }
    }
}
