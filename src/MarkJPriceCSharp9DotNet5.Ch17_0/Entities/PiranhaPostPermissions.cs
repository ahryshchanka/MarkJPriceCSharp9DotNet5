namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPostPermissions
    {
        public string PostId { get; set; }
        public string Permission { get; set; }

        public virtual PiranhaPosts Post { get; set; }
    }
}