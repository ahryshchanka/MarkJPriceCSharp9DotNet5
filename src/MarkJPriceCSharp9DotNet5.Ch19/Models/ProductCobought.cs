using Microsoft.ML.Data;

namespace MarkJPriceCSharp9DotNet5.Ch19.Models
{
    public class ProductCobought
    {
        [KeyType(77)]
        public uint ProductId { get; set; }

        [KeyType(77)]
        public uint CoboughtProductId { get; set; }
    }
}