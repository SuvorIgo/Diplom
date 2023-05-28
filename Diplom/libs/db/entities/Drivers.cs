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
        public int DriverId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("patronymic")]
        public string Patronymic { get; set; }

        [Column("driving_experience")]
        public string DrivingExperience { get; set; }

        [Column("date_adoption")]
        public DateTime? DateAdoption { get; set; } = DateTime.Now.Date;

        public List<TransportsDrivers> TransportsDrivers { get; set; } = new();
    }
}
