using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarkJPriceCSharp9DotNet5.Ch20.Shared.Entities
{
    [Keyless]
    public partial class EmployeeTerritory
    {
        [Column("EmployeeID", TypeName = "int")]
        public long EmployeeId { get; set; }
        [Required]
        [Column("TerritoryID", TypeName = "nvarchar")]
        public string TerritoryId { get; set; }
    }
}