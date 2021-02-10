using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarkJPriceCSharp9DotNet5.Ch12.Models
{
    [Index(nameof(LastName), Name = "LastName")]
    [Index(nameof(PostalCode), Name = "PostalCodeEmployees")]
    public partial class Employee
    {
        public Employee() => Orders = new HashSet<Order>();

        [Key]
        [Column("EmployeeID")]
        public long EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (20)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar (10)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar (30)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar (25)")]
        public string TitleOfCourtesy { get; set; }

        [Column(TypeName = "datetime")]
        public byte[] BirthDate { get; set; }

        [Column(TypeName = "datetime")]
        public byte[] HireDate { get; set; }

        [Column(TypeName = "nvarchar (60)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar (15)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar (15)")]
        public string Region { get; set; }

        [Column(TypeName = "nvarchar (10)")]
        public string PostalCode { get; set; }

        [Column(TypeName = "nvarchar (15)")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar (24)")]
        public string HomePhone { get; set; }

        [Column(TypeName = "nvarchar (4)")]
        public string Extension { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        [Column(TypeName = "int")]
        public long? ReportsTo { get; set; }

        [Column(TypeName = "nvarchar (255)")]
        public string PhotoPath { get; set; }

        [InverseProperty(nameof(Order.Employee))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}