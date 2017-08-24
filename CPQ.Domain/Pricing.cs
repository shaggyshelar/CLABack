using System;

namespace CPQ.Domain
{
    public class Pricing
    {
        public Guid PriceListId { get; set; }
        public string PriceListName { get; set; }
        public string PriceListType { get; set; }
        public decimal Amount { get; set; }
    }
}
