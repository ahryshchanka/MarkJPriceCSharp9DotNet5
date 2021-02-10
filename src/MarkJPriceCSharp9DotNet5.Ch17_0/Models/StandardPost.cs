using Piranha.AttributeBuilder;
using Piranha.Models;
using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Models
{
    [PostType(Title = "Standard post")]
    public class StandardPost : Post<StandardPost>
    {
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}