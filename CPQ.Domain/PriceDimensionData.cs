using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class PriceDimensionData
    {
        public string Name { get; set; }
        public EntityReference ProductId { get; set; }
        public double Quantity { get; set; }
        public Money ListPrice { get; set; }
        public decimal Uplift { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal AdditionalDiscount { get; set; }
        public Money NetUnitPrice { get; set; }
        public Money NetTotal { get; set; }
    }
}
