using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("Transportations")]
    public class Transportations
    {
        [Key]
        [Column("transportation_id")]
        public int Transportation_id { get; set; }

        //public int order_id { get; set; } многие-к-одному в Orders
        //public int transportDriver_id { get; set; } многие-к-одному в TransportsDrivers
        public string Tracking_code { get; set; }
    }
}
