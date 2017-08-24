using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class PricingRule
    {
        public string PriceRuleName { get; set; }
        public Guid PriceRuleId { get; set; }
        public string ConditionMet { get; set; }
        public string EvaluationScope { get; set; }
        public string EvaluationOrder { get; set; }
        public string CalculatorEvaluationEvent { get; set; }
        public string ConfiguratorEvaluationEvent { get; set; }
        public List<PriceCondition> ErrorConditions { get; set; }
        public List<PriceAction> ActionConditions { get; set; }
    }
}
