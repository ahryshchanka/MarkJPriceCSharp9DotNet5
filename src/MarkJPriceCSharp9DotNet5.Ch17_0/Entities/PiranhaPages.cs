using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPages
    {
        public PiranhaPages()
        {
            InverseParent = new HashSet<PiranhaPages>();
            PiranhaCategories = new HashSet<PiranhaCategories>();
            PiranhaPageBlocks = new HashSet<PiranhaPageBlocks>();
            PiranhaPageComments = new HashSet<PiranhaPageComments>();
            PiranhaPageFields = new HashSet<PiranhaPageFields>();
            PiranhaPagePermissions = new HashSet<PiranhaPagePermissions>();
            PiranhaPageRevisions = new HashSet<PiranhaPageRevisions>();
            PiranhaPosts = new HashSet<PiranhaPosts>();
            PiranhaTags = new HashSet<PiranhaTags>();
        }

        public string Id { get; set; }
        public string Created { get; set; }
        public long IsHidden { get; set; }
        public string LastModified { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string NavigationTitle { get; set; }
        public string PageTypeId { get; set; }
        public string ParentId { get; set; }
        public string Published { get; set; }
        public long RedirectType { get; set; }
        public string RedirectUrl { get; set; }
        public string Route { get; set; }
        public string SiteId { get; set; }
        public string Slug { get; set; }
        public long SortOrder { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public string OriginalPageId { get; set; }
        public long CloseCommentsAfterDays { get; set; }
        public long EnableComments { get; set; }
        public string Excerpt { get; set; }
        public string PrimaryImageId { get; set; }
        public string MetaTitle { get; set; }
        public string OgDescription { get; set; }
        public string OgImageId { get; set; }
        public string OgTitle { get; set; }

        public virtual PiranhaPageTypes PageType { get; set; }
        public virtual PiranhaPages Parent { get; set; }
        public virtual PiranhaSites Site { get; set; }
        public virtual ICollection<PiranhaPages> InverseParent { get; set; }
        public virtual ICollection<PiranhaCategories> PiranhaCategories { get; set; }
        public virtual ICollection<PiranhaPageBlocks> PiranhaPageBlocks { get; set; }
        public virtual ICollection<PiranhaPageComments> PiranhaPageComments { get; set; }
        public virtual ICollection<PiranhaPageFields> PiranhaPageFields { get; set; }
        public virtual ICollection<PiranhaPagePermissions> PiranhaPagePermissions { get; set; }
        public virtual ICollection<PiranhaPageRevisions> PiranhaPageRevisions { get; set; }
        public virtual ICollection<PiranhaPosts> PiranhaPosts { get; set; }
        public virtual ICollection<PiranhaTags> PiranhaTags { get; set; }
    }
}