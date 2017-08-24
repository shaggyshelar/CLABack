using Microsoft.Xrm.Sdk;

namespace CPQ.Domain
{
    public class BlockPrice
    {
        public string PriceName { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
        public EntityReference ProductId { get; set; }
        public EntityReference PriceBookId { get; set; }
        public Money Price { get; set; }
    }
}
