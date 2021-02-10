using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Models
{
    public class ProductRegion
    {
        [Field(Title = "Product Id")]
        public NumberField ProductId { get; set; }

        [Field(Title = "Product name")]
        public TextField ProductName { get; set; }

        [Field(Title = "Unit price", Options = FieldOption.HalfWidth)]
        public StringField UnitPrice { get; set; }

        [Field(Title = "Units in stock", Options = FieldOption.HalfWidth)]
        public NumberField UnitsInStock { get; set; }
    }
}