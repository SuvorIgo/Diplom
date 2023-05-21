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

        [Column("order_id")]
        public int OrderId { get; set; }
        public Orders? Orders { get; set; }

        [Column("transportDriver_id")]
        public int TransportDriverId { get; set; }
        public TransportsDrivers? transportsDrivers { get; set; }

        [Column("tracking_code")]
        public string TrackingCode { get; set; }
    }
}
