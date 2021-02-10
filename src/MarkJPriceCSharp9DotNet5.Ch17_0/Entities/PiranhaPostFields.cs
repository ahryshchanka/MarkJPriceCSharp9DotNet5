namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaPostFields
    {
        public string Id { get; set; }
        public string Clrtype { get; set; }
        public string FieldId { get; set; }
        public string PostId { get; set; }
        public string RegionId { get; set; }
        public long SortOrder { get; set; }
        public string Value { get; set; }

        public virtual PiranhaPosts Post { get; set; }
    }
}