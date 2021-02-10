namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPagePermissions
    {
        public string PageId { get; set; }
        public string Permission { get; set; }

        public virtual PiranhaPages Page { get; set; }
    }
}