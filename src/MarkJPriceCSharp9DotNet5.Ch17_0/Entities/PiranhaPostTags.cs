namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPostTags
    {
        public string PostId { get; set; }
        public string TagId { get; set; }

        public virtual PiranhaPosts Post { get; set; }
        public virtual PiranhaTags Tag { get; set; }
    }
}