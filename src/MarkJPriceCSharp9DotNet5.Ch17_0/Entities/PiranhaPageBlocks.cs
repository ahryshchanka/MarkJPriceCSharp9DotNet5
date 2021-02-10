namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPageBlocks
    {
        public string Id { get; set; }
        public string BlockId { get; set; }
        public string PageId { get; set; }
        public long SortOrder { get; set; }
        public string ParentId { get; set; }

        public virtual PiranhaBlocks Block { get; set; }
        public virtual PiranhaPages Page { get; set; }
    }
}