using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarkJPriceCSharp9DotNet5.Ch16.Models
{
    public partial class Shipper
    {
        public Shipper() => Orders = new HashSet<Order>();

        [Key]
        [Column("ShipperID")]
        public long ShipperId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (40)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "nvarchar (24)")]
        public string Phone { get; set; }

        [InverseProperty(nameof(Order.ShipViaNavigation))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}