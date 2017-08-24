using Microsoft.Xrm.Sdk;
using System;

namespace CPQ.Domain
{
    public class DiscountTiers
    {
        public Guid TierId { get; set; }
        public string Name { get; set; }
        public double LowerBound { get; set; }
        public double UpperBound { get; set; }
        public double DiscountPercent { get; set; }
        public Money DiscountAmount { get; set; }
    }
}
