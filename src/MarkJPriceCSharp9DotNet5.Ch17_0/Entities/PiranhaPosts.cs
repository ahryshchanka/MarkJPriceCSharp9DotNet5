using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPosts
    {
        public PiranhaPosts()
        {
            PiranhaPostBlocks = new HashSet<PiranhaPostBlocks>();
            PiranhaPostComments = new HashSet<PiranhaPostComments>();
            PiranhaPostFields = new HashSet<PiranhaPostFields>();
            PiranhaPostPermissions = new HashSet<PiranhaPostPermissions>();
            PiranhaPostRevisions = new HashSet<PiranhaPostRevisions>();
            PiranhaPostTags = new HashSet<PiranhaPostTags>();
        }

        public string Id { get; set; }
        public string BlogId { get; set; }
        public string CategoryId { get; set; }
        public string Created { get; set; }
        public string LastModified { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string PostTypeId { get; set; }
        public string Published { get; set; }
        public long RedirectType { get; set; }
        public string RedirectUrl { get; set; }
        public string Route { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public long CloseCommentsAfterDays { get; set; }
        public long EnableComments { get; set; }
        public string Excerpt { get; set; }
        public string PrimaryImageId { get; set; }
        public string MetaTitle { get; set; }
        public string OgDescription { get; set; }
        public string OgImageId { get; set; }
        public string OgTitle { get; set; }

        public virtual PiranhaPages Blog { get; set; }
        public virtual PiranhaCategories Category { get; set; }
        public virtual PiranhaPostTypes PostType { get; set; }
        public virtual ICollection<PiranhaPostBlocks> PiranhaPostBlocks { get; set; }
        public virtual ICollection<PiranhaPostComments> PiranhaPostComments { get; set; }
        public virtual ICollection<PiranhaPostFields> PiranhaPostFields { get; set; }
        public virtual ICollection<PiranhaPostPermissions> PiranhaPostPermissions { get; set; }
        public virtual ICollection<PiranhaPostRevisions> PiranhaPostRevisions { get; set; }
        public virtual ICollection<PiranhaPostTags> PiranhaPostTags { get; set; }
    }
}