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

        //public int driver_id { get; set; } многие-к-одному в Drivers
        //public int transport_id { get; set; } многие-к-одному в Transports 
    }
}
