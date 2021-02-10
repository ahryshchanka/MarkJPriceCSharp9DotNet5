using MarkJPriceCSharp9DotNet5.Ch19.Entities;
using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch19.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public bool GermanyDatasetExists { get; set; }
        public bool UKDatasetExists { get; set; }
        public bool USADatasetExists { get; set; }
        public long Milliseconds { get; set; }
    }
}