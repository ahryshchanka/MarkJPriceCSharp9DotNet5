using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MarkJPriceCSharp9DotNet5.Ch12.Models
{
    [Keyless]
    public partial class Territory
    {
        [Required]
        [Column("TerritoryID", TypeName = "nvarchar")]
        public string TerritoryId { get; set; }

        [Required]
        [Column(TypeName = "nchar")]
        public string TerritoryDescription { get; set; }

        [Column("RegionID", TypeName = "int")]
        public long RegionId { get; set; }
    }
}