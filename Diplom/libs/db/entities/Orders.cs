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

        [Column("tonnage")]
        public int Tonnage { get; set; }

        [Column("name_company")]
        public string NameCompany { get; set; }

        [Column("number_phone")]
        public string NumberPhone { get; set; }

        [Column("point_departure")]
        public string? PointDeparture { get; set; }

        [Column("point_reception")]
        public string? PointReception { get; set; }

        [ForeignKey("user_id")]
        public Users? Users { get; set; }

        public List<Transportations> Transportations { get; set; } = new();
    }
}
