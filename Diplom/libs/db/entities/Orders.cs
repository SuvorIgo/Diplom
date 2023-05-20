using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db.entities
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [Column("order_id")]
        public int Order_id { get; set; }

        public int Tonnage { get; set; }
        public string Name_company { get; set; }
        public string Number_phone { get; set; }
        public string? Point_departure { get; set; }
        public string? Point_reception { get; set; }
        //public int user_id { get; set; } многие-к-одному в Users
    }
}
