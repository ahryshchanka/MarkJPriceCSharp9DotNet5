using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaMedia
    {
        public PiranhaMedia()
        {
            PiranhaMediaVersions = new HashSet<PiranhaMediaVersions>();
        }

        public string Id { get; set; }
        public string ContentType { get; set; }
        public string Created { get; set; }
        public string Filename { get; set; }
        public string FolderId { get; set; }
        public string LastModified { get; set; }
        public string PublicUrl { get; set; }
        public long Size { get; set; }
        public long Type { get; set; }
        public long? Height { get; set; }
        public long? Width { get; set; }
        public string AltText { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public string Title { get; set; }

        public virtual PiranhaMediaFolders Folder { get; set; }
        public virtual ICollection<PiranhaMediaVersions> PiranhaMediaVersions { get; set; }
    }
}