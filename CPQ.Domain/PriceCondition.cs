using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class PriceCondition
    {
        public Guid PriceConditionId { get; set; }
        public Guid PriceRuleId { get; set; }

        public OptionSetValue FilterType { get; set; }
        public string FilterValue { get; set; }
        public EntityReference FilterVariable { get; set; }
        public string FilterFormula { get; set; }
        public OptionSetValue Operator { get; set; }

        public string TestedFormula { get; set; }
        public EntityReference TestedAttribute { get; set; }
        public EntityReference Field { get; set; }
        public EntityReference Object { get; set; }
        public EntityReference TestedVariable { get; set; }
    }
}
