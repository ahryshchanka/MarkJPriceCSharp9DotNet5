namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaBlockFields
    {
        public string Id { get; set; }
        public string BlockId { get; set; }
        public string Clrtype { get; set; }
        public string FieldId { get; set; }
        public long SortOrder { get; set; }
        public string Value { get; set; }

        public virtual PiranhaBlocks Block { get; set; }
    }
}