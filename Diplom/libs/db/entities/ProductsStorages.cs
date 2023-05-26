using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("ProductsStorages")]
    public class ProductsStorages
    {
        [Key]
        [Column("productsStorages_id")]
        public int ProductsStoragesId { get; set; }

        [ForeignKey("storage_id")]
        public Storages? Storages { get; set; }

        [ForeignKey("product_id")]
        public Products? Products { get; set; }

        [Column("volume")]
        public string Volume { get; set; }
    }
}
