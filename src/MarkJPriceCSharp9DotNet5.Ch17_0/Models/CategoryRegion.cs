using Piranha.Extend;
using Piranha.Extend.Fields;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Models
{
    public class CategoryRegion
    {
        [Field(Title = "Category Id")]
        public NumberField CategoryId { get; set; }

        [Field(Title = "Category name")]
        public TextField CategoryName { get; set; }

        [Field]
        public HtmlField Description { get; set; }

        [Field(Title = "Category image")]
        public ImageField CategoryImage { get; set; }
    }
}