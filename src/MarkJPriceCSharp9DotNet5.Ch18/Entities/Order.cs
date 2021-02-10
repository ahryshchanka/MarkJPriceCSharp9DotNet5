using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarkJPriceCSharp9DotNet5.Ch18.Entities
{
    [Index(nameof(CustomerId), Name = "CustomerID")]
    [Index(nameof(CustomerId), Name = "CustomersOrders")]
    [Index(nameof(EmployeeId), Name = "EmployeeID")]
    [Index(nameof(EmployeeId), Name = "EmployeesOrders")]
    [Index(nameof(OrderDate), Name = "OrderDate")]
    [Index(nameof(ShipPostalCode), Name = "ShipPostalCode")]
    [Index(nameof(ShippedDate), Name = "ShippedDate")]
    [Index(nameof(ShipVia), Name = "ShippersOrders")]
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("OrderID")]
        public long OrderId { get; set; }
        [Column("CustomerID", TypeName = "nchar (5)")]
        public string CustomerId { get; set; }
        [Column("EmployeeID", TypeName = "int")]
        public long? EmployeeId { get; set; }
        [Column(TypeName = "datetime")]
        public byte[] OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public byte[] RequiredDate { get; set; }
        [Column(TypeName = "datetime")]
        public byte[] ShippedDate { get; set; }
        [Column(TypeName = "int")]
        public long? ShipVia { get; set; }
        [Column(TypeName = "money")]
        public byte[] Freight { get; set; }
        [Column(TypeName = "nvarchar (40)")]
        public string ShipName { get; set; }
        [Column(TypeName = "nvarchar (60)")]
        public string ShipAddress { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string ShipCity { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string ShipRegion { get; set; }
        [Column(TypeName = "nvarchar (10)")]
        public string ShipPostalCode { get; set; }
        [Column(TypeName = "nvarchar (15)")]
        public string ShipCountry { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("Orders")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(ShipVia))]
        [InverseProperty(nameof(Shipper.Orders))]
        public virtual Shipper ShipViaNavigation { get; set; }
        [InverseProperty(nameof(OrderDetail.Order))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}