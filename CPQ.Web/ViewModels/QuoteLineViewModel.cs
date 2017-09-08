using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class QuoteLineViewModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string ParentName { get; set; }
        public bool IsBundle { get; set; }
        public string GroupId { get; set; }
        public bool Optional { get; set; }
        public bool Taxable { get; set; }
        public int? DecimalsSupported { get; set; }
        public int? DefaultQuantity { get; set; }
        public bool IsReconfigurationDisabled { get; set; }
        public QuantityViewModel Quantity { get; set; }
        public DiscountScheduleViewModel DiscountSchedule { get; set; }
        public bool CanClone { get; set; }
        public int SubscriptionTerm { get; set; }
        public string TermDiscountLevel { get; set; }
        public bool CanSegment { get; set; }
        public int? DecimalSupported { get; set; }

        public SegmentDataViewModel SegmentData { get; set; }
        public bool CanReconfigure { get; set; }
        public bool CanShowDiscountScheduler { get; set; }
        public ListPriceViewModel ListPrice { get; set; }
        public AdditionalDiscountViewModel AdditionalDiscount { get; set; }
        public decimal Markup { get; set; }
        public decimal NetUnitPrice { get; set; }
        public Decimal TotalPrice { get; set; }
        public Decimal NetTotal { get; set; }
        public PricingMethodViewModel PricingMethod { get; set; }

        public QuoteLineViewModel()
        {
            Quantity = new QuantityViewModel();
            DiscountSchedule = new DiscountScheduleViewModel();
            SegmentData = new SegmentDataViewModel();
            ListPrice = new ListPriceViewModel();
            AdditionalDiscount = new AdditionalDiscountViewModel();
            PricingMethod = new PricingMethodViewModel();
        }
    }
}