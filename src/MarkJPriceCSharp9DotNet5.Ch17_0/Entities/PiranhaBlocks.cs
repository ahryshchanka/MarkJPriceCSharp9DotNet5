using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaBlocks
    {
        public PiranhaBlocks()
        {
            PiranhaBlockFields = new HashSet<PiranhaBlockFields>();
            PiranhaPageBlocks = new HashSet<PiranhaPageBlocks>();
            PiranhaPostBlocks = new HashSet<PiranhaPostBlocks>();
        }

        public string Id { get; set; }
        public string Clrtype { get; set; }
        public string Created { get; set; }
        public long IsReusable { get; set; }
        public string LastModified { get; set; }
        public string Title { get; set; }
        public string ParentId { get; set; }

        public virtual ICollection<PiranhaBlockFields> PiranhaBlockFields { get; set; }
        public virtual ICollection<PiranhaPageBlocks> PiranhaPageBlocks { get; set; }
        public virtual ICollection<PiranhaPostBlocks> PiranhaPostBlocks { get; set; }
    }
}