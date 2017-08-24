using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class ProductRule
    {
        public string ProductRuleName { get; set; }
        public Guid ProductRuleId { get; set; }
        public OptionSetValue ConditionMet { get; set; }
        public OptionSetValue Scope { get; set; }
        public OptionSetValue EvaluationEvent { get; set; }
        public OptionSetValue Type { get; set; }
        public string ErrorMessage { get; set; }
        public double EvaluationOrder { get; set; }
        public List<ErrorCondition> ErrorConditions { get; set; }
        public List<ProductAction> ActionConditions { get; set; }

        public List<ConfigurationRule> ConfigurationRules { get; set; }
    }
}
