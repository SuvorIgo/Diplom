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
        public int Product_id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("volume")]
        public int Volume { get; set; }

        //public int storage_id { get; set; } многие-к-одному в Storages
    }
}
