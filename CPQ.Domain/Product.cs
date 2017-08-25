using CPQ.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class Product : BaseEntity
    {
        [Bindable]
        public Guid Id { get; set; }
        [Bindable]
        public string Name { get; set; }
        [Bindable]
        public string ProductCode { get; set; }
        [Bindable]
        public string Description { get; set; }
        [Bindable]
        public string ProductStrucuture { get; set; }
        public string DefaultQuantity { get; set; }
        public string SubscriptionType { get; set; }
        public string SubscriptionPricing { get; set; }
        [Bindable]
        public decimal StandardPrice { get; set; }
        public List<PriceDimension> Dimensions { get; set; }

        public List<ProductOption> Options { get; set; }
        public Pricing PricingDetails { get; set; }
        public List<ProductRule> ProductRules { get; set; }
        public List<PricingRule> PriceRules { get; set; }
        public Guid DiscountList { get; set; }
        public DiscountSchedule DiscountSchedule { get; set; }
        public List<ConfigurationRule> ConfigurationRules { get; set; }
        public List<ConfigurationAttribute> ConfigurationAttributes { get; set; }
        public List<ProductFeature> Features { get; set; }
        public PriceListItem PriceListItem { get; set; }
        public Subscription Subscriptions { get; set; }
        public bool IsAllowBlockPrice { get; set; }
        public List<BlockPrice> BlockPrice { get; set; }
        public List<Cost> Cost { get; set; }
        public List<PriceDimension> PriceDimension { get; set; }
        public List<OptionConstraint> OptionConstraint { get; set; }
        public List<ProductCategory> Categories { get; set; }

        public string QuantityEditable { get; set; }
        public string PriceEditable { get; set; }
    }
}
