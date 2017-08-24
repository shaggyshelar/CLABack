using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class ProductFeature
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }
        public int MinOptions { get; set; }
        public int MaxOptions { get; set; }
        public int Number { get; set; }
        public EntityReference ConfiguredSku { get; set; }
        public EntityReference Category { get; set; }
        public EntityReference DiscountSchedule { get; set; }
        public OptionSetValue OptionSelectionMethod { get; set; }
    }
}
