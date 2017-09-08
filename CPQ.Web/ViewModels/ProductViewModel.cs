using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string ParentName { get; set; }
        public string Type { get; set; }
        public bool IsBundle { get; set; }
        public string ProductStructure { get; set; }
        public bool? IsBundled { get; set; }
        public bool CanClone { get; set; }
        public bool CanSegment { get; set; }
        public bool CanReconfigure { get; set; }
        public bool CanShowDiscountScheduler { get; set; }
        public bool Optional { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsReconfigurationDisabled { get; set; }

        public string QuoteId { get; set; }
        public string GroupId { get; set; }
        public int? DecimalsSupported { get; set; }
        public int? DefaultQuantity { get; set; }
        public QuantityViewModel Quantity { get; set; }
        public ListPriceViewModel ListPrice { get; set; }
        public PricingMethodViewModel PricingMethod { get; set; }
        public DiscountScheduleViewModel DiscountSchedule { get; set; }
        public int? DecimalSupported { get; set; }

        public int SubscriptionTerm { get; set; }
        public string TermDiscountLevel { get; set; }
        public SegmentDataViewModel SegmentData { get; set; }

        public AdditionalDiscountViewModel AdditionalDiscount { get; set; }
        public decimal Markup { get; set; }
        public decimal NetUnitPrice { get; set; }
        public Decimal TotalPrice { get; set; }

        public string FeatureId { get; set; }
        public string CategoryId { get; set; }
        public bool IsDependent { get; set; }
        public bool? IsSelected { get; set; }
        public bool IsRequired { get; set; }

        // public string optionSelectionMethod { get; set; }
        public string OptionLayout { get; set; }

        public List<CategoriesViewModel> Categories { get; set; }
        public List<FeaturesViewModel> Features { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public ProductViewModel()
        {
            Products = new List<ProductViewModel>();
            Categories = new List<CategoriesViewModel>();
            Features = new List<FeaturesViewModel>();
            ListPrice = new ListPriceViewModel();
            AdditionalDiscount = new AdditionalDiscountViewModel();
        }
    }
}