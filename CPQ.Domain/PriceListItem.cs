using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class PriceListItem
    {
        public EntityReference CreatedOn { get; set; }
        public Guid ProductPriceLevelId { get; set; }
        public EntityReference PricelevelId { get; set; }
        public EntityReference ProductId { get; set; }
        public EntityReference UomId { get; set; }
        public EntityReference DiscountTypeId { get; set; }
        public OptionSetValue QuantitySellingCode { get; set; }
        public OptionSetValue RoundingPolicyCode { get; set; }
        public OptionSetValue RoundingOptionCode { get; set; }
        public OptionSetValue PricingMethodCode { get; set; }
        public Money Amount { get; set; }
        public decimal Percentage { get; set; }
    }
}
