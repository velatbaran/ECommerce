using ECommerce.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Web.Models
{
    public class ProductModel : BaseModel
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez."), StringLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Description { get; set; }

        [DisplayName("Resim")]
        public string Image { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public decimal Price { get; set; }

        [DisplayName("Miktar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public int Amount { get; set; }

        [DisplayName("Stokta Var Mı?")]
        public bool IsStock { get; set; }

        public List<Category> SelectedCategories { get; set; }
    }
}
