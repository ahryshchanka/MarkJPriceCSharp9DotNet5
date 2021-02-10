namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPostRevisions
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public string Created { get; set; }
        public string PostId { get; set; }

        public virtual PiranhaPosts Post { get; set; }
    }
}