using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("Drivers")]
    public class Drivers
    {
        [Key]
        [Column("driver_id")]
        public int Driver_id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Patronymic { get; set; }
        public string Driving_experience { get; set; }
        public DateTime? Date_adoption { get; set; }
    }
}
