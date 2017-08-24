using Microsoft.Xrm.Sdk;
using System;

namespace CPQ.Domain
{
    public class ErrorCondition
    {
        public EntityReference createdby { get; set; }
        public DateTime createdon { get; set; }
        public Guid ErrorConditionId { get; set; }
        public OptionSetValue FilterType { get; set; }
        public string FilterValue { get; set; }
        public EntityReference FilterVariable { get; set; }
        public int Index { get; set; }
        public string ErrorConditionName { get; set; }
        public OptionSetValue Operator { get; set; }
        public bool IsParentRuleActive { get; set; }
        public EntityReference Rule { get; set; }
        public bool RuleTargetQuote { get; set; }
        public EntityReference TestedAttribute { get; set; }
        public EntityReference TestedField { get; set; }
        public EntityReference TestedObject { get; set; }
        public EntityReference TestedVariable { get; set; }
    }
}
