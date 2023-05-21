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
        public int TransportationId { get; set; }

        [ForeignKey("order_id")]
        public Orders? Orders { get; set; }

        [ForeignKey("transportsDriver_id")]
        public TransportsDrivers? transportsDrivers { get; set; }

        [Column("tracking_code")]
        public string TrackingCode { get; set; }
    }
}
