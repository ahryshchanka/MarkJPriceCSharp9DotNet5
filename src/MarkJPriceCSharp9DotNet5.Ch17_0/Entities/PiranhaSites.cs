using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaSites
    {
        public PiranhaSites()
        {
            PiranhaAliases = new HashSet<PiranhaAliases>();
            PiranhaPages = new HashSet<PiranhaPages>();
            PiranhaSiteFields = new HashSet<PiranhaSiteFields>();
        }

        public string Id { get; set; }
        public string Created { get; set; }
        public string Description { get; set; }
        public string Hostnames { get; set; }
        public string InternalId { get; set; }
        public long IsDefault { get; set; }
        public string LastModified { get; set; }
        public string Title { get; set; }
        public string SiteTypeId { get; set; }
        public string ContentLastModified { get; set; }
        public string Culture { get; set; }
        public string LogoId { get; set; }

        public virtual ICollection<PiranhaAliases> PiranhaAliases { get; set; }
        public virtual ICollection<PiranhaPages> PiranhaPages { get; set; }
        public virtual ICollection<PiranhaSiteFields> PiranhaSiteFields { get; set; }
    }
}