using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch19.Models
{
    public class HomeCartViewModel
    {
        public Cart Cart { get; set; }
        public List<EnrichedRecommendation> Recommendations { get; set; }
        public bool GermanyDatasetExists { get; set; }
        public bool UKDatasetExists { get; set; }
        public bool USADatasetExists { get; set; }
        public long Milliseconds { get; set; }
    }
}