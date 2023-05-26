using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("volume")]
        public int Volume { get; set; }

        [ForeignKey("storage_id")]
        public Storages? Storages { get; set; }

        [ForeignKey("category_id")]
        public Categories? Categories { get; set; }

        public List<Orders> Orders { get; set; } = new();
    }
}
