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

        [Column("name")]
        public string Name { get; set; }

        [Column("brand")]
        public string Brand { get; set; }

        [Column("load_capacity")]
        public int LoadCapacity { get; set; }

        [Column("year_prod")]
        public int YearProd { get; set; }

        [Column("photo")]
        public string? Photo { get; set; }
    }
}
