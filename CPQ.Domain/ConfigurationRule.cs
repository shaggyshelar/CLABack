using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class ConfigurationRule
    {
        public Guid ConfigurationRuleId { get; set; }
        public string ConfigurationRuleName { get; set; }
        public EntityReference ProductId { get; set; }
        public EntityReference ProductFeature { get; set; }
        public EntityReference ProductRule { get; set; }
        public OptionSetValue RuleType { get; set; }
        public OptionSetValue EvaluationEvent { get; set; }
    }
}
