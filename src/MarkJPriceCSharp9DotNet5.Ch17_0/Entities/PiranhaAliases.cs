namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaAliases
    {
        public string Id { get; set; }
        public string AliasUrl { get; set; }
        public string Created { get; set; }
        public string LastModified { get; set; }
        public string RedirectUrl { get; set; }
        public string SiteId { get; set; }
        public long Type { get; set; }

        public virtual PiranhaSites Site { get; set; }
    }
}