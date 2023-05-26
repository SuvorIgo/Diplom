using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("Storages")]
    public class Storages
    {
        [Key]
        [Column("storage_id")]
        public int StorageId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("accomodation")]
        public int Accommodation { get; set; }

        public List<ProductsStorages> ProductsStorages { get; set; } = new();
    }
}
