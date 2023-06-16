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

        [Column("departure_date")]
        public DateTime? DepartureDate { get; set; } = DateTime.Now.Date.AddDays(2);

        [Column("arrival_date")]
        public DateTime? ArrivalDate { get; set; }

        [Column("cost")]
        public int? Cost { get; set; }

        [Column("comment")]
        public string? Comment { get; set; }
    }
}
