namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPageRevisions
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public string Created { get; set; }
        public string PageId { get; set; }

        public virtual PiranhaPages Page { get; set; }
    }
}