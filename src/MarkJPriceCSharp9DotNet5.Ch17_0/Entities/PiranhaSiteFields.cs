namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaSiteFields
    {
        public string Id { get; set; }
        public string Clrtype { get; set; }
        public string FieldId { get; set; }
        public string RegionId { get; set; }
        public string SiteId { get; set; }
        public long SortOrder { get; set; }
        public string Value { get; set; }

        public virtual PiranhaSites Site { get; set; }
    }
}