using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaTags
    {
        public PiranhaTags()
        {
            PiranhaPostTags = new HashSet<PiranhaPostTags>();
        }

        public string Id { get; set; }
        public string BlogId { get; set; }
        public string Created { get; set; }
        public string LastModified { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }

        public virtual PiranhaPages Blog { get; set; }
        public virtual ICollection<PiranhaPostTags> PiranhaPostTags { get; set; }
    }
}