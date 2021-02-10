using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaMediaFolders
    {
        public PiranhaMediaFolders()
        {
            PiranhaMedia = new HashSet<PiranhaMedia>();
        }

        public string Id { get; set; }
        public string Created { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PiranhaMedia> PiranhaMedia { get; set; }
    }
}