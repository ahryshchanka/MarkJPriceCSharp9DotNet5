using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPageTypes
    {
        public PiranhaPageTypes()
        {
            PiranhaPages = new HashSet<PiranhaPages>();
        }

        public string Id { get; set; }
        public string Body { get; set; }
        public string Created { get; set; }
        public string LastModified { get; set; }
        public string Clrtype { get; set; }

        public virtual ICollection<PiranhaPages> PiranhaPages { get; set; }
    }
}