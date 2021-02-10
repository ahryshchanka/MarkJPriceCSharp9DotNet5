namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPageComments
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public long IsApproved { get; set; }
        public string Body { get; set; }
        public string Created { get; set; }
        public string PageId { get; set; }

        public virtual PiranhaPages Page { get; set; }
    }
}