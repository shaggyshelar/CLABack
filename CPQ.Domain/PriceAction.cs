using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class PriceAction
    {
        public Guid PriceActionId { get; set; }
        public Guid PriceRuleId { get; set; }
        public EntityReference TargetObject { get; set; }
        public EntityReference TargetField { get; set; }
        public string Value { get; set; }
        public string Formula { get; set; }
    }
}
