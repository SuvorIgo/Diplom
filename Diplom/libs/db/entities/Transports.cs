using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("Transports")]
    public class Transports
    {
        [Key]
        [Column("transport_id")]
        public int Transport_id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Load_capacity { get; set; }
        public int Year_prod { get; set; }
        public string? Photo { get; set; }
    }
}
