using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("TransportsDrivers")]
    public class TransportsDrivers
    {
        [Key]
        [Column("transportsDriver_id")]
        public int TransportsDriverId { get; set; }

        [ForeignKey("driver_id")]
        public Drivers? Drivers { get; set; }

        [ForeignKey("transport_id")]
        public Transports? Transports { get; set; }

        public List<Transportations> Transportations { get; set; } = new();
    }
}
