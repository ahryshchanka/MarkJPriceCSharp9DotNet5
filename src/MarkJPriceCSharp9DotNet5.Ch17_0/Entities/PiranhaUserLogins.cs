namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public virtual PiranhaUsers User { get; set; }
    }
}