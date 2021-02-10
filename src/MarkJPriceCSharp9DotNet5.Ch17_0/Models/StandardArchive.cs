using Piranha.AttributeBuilder;
using Piranha.Models;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Models
{
    [PageType(Title = "Standard archive", IsArchive = true)]
    public class StandardArchive : Page<StandardArchive>
    {
        public PostArchive<PostInfo> Archive { get; set; }
    }
}