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
        public int OrderId { get; set; }

        [Column("tonnage")]
        public int Tonnage { get; set; }

        [Column("name_company")]
        public string NameCompany { get; set; }

        [Column("number_phone")]
        public string NumberPhone { get; set; }

        [Column("point_reception")]
        public string? PointReception { get; set; }

        [Column("progress")]
        public string? Progress { get; set; }

        [ForeignKey("user_id")]
        public Users? Users { get; set; }

        [ForeignKey("product_id")]
        public Products? Products { get; set; }

        public List<Transportations> Transportations { get; set; } = new();
    }
}
