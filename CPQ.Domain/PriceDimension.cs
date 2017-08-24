using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class PriceDimension
    {
        public Guid DimensionId { get; set; }
        public EntityReference ProductId { get; set; }
        public string DimensionName { get; set; }
        public OptionSetValue Type { get; set; }

        public EntityReference PriceBookId { get; set; }
        public Money UnitPrice { get; set; }
        public int DefaultQuantity { get; set; }
        public bool NonDiscountable { get; set; }
        public bool NonPartnerDiscountable { get; set; }
        public bool PriceEditable { get; set; }
        public bool CostEditable { get; set; }
        public bool Taxable { get; set; }
        public EntityReference DiscountList { get; set; }
        public EntityReference DiscountSchedule { get; set; }

        public List<PriceDimensionData> DimensionData { get; set; }
    }
}
