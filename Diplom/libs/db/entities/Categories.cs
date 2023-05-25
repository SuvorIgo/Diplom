using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public List<Products> Products { get; set; } = new();
    }
}
