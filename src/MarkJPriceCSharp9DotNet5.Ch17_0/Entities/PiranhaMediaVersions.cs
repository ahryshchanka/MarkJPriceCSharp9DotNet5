namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaMediaVersions
    {
        public string Id { get; set; }
        public long? Height { get; set; }
        public string MediaId { get; set; }
        public long Size { get; set; }
        public long Width { get; set; }
        public string FileExtension { get; set; }

        public virtual PiranhaMedia Media { get; set; }
    }
}