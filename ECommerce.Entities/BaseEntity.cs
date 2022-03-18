using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Kayıt Tarihi")]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Kaydeden")]
        public string CreatedUsername { get; set; }

        [DisplayName("Güncelleme Tarihi")]
        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedDate { get; set; }

        [DisplayName("Güncelleyen")]
        public string ModifiedUsername { get; set; }

        [DisplayName("Silindi Mi?")]
        public bool IsDeleted { get; set; }

        [DisplayName("Silme Tarihi")]
        [Column(TypeName = "datetime2")]
        public DateTime? DeletedDate { get; set; }

        [DisplayName("Silen")]
        public string DeletedUsername { get; set; }
    }
}
