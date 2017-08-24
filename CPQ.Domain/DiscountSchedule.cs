using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class DiscountSchedule
    {
        public Guid DiscountScheduleId { get; set; }
        public string Name { get; set; }
        public OptionSetValue DiscountUnit { get; set; }
        public OptionSetValue Type { get; set; }
        public EntityReference Product { get; set; }
        public bool CrossProducts { get; set; }
        public bool IncludeBundledQuantities { get; set; }
        // public OptionSetValue ConstraintField { get; set; }
        public OptionSetValue AggregationScope { get; set; }
        public List<DiscountTiers> DiscountTiers { get; set; }
    }
}
