using Piranha.AttributeBuilder;
using Piranha.Models;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Models
{
    [PageType(Title = "Catalog page", UseBlocks = false)]
    [PageTypeRoute(Title = "Default", Route = "/catalog")]
    public class CatalogPage : Page<CatalogPage>
    {
    }
}