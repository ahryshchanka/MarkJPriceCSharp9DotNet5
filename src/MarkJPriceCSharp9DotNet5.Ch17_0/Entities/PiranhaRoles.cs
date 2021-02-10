using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaRoles
    {
        public PiranhaRoles()
        {
            PiranhaRoleClaims = new HashSet<PiranhaRoleClaims>();
            PiranhaUserRoles = new HashSet<PiranhaUserRoles>();
        }

        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public virtual ICollection<PiranhaRoleClaims> PiranhaRoleClaims { get; set; }
        public virtual ICollection<PiranhaUserRoles> PiranhaUserRoles { get; set; }
    }
}