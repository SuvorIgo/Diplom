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
        public int TransportsDriver_id { get; set; }

        [Column("driver_id")]
        public int DriverId { get; set; }
        public Drivers? Drivers { get; set; }

        [Column("transport_id")]
        public int TransportId { get; set; }
        public Transports? Transports { get; set; }

        public List<Transportations> Transportations { get; set; } = new();
    }
}
