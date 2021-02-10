using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Models
{
    public class CatalogViewModel
    {
        public CatalogPage CatalogPage { get; set; }
        public IEnumerable<CategoryItem> Categories { get; set; }
    }
}