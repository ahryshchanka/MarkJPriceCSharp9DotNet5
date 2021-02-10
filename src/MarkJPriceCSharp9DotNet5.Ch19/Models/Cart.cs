using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch19.Models
{
    public class Cart
    {
        public IEnumerable<CartItem> Items { get; set; }
    }
}