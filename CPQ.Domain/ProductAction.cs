using Microsoft.Xrm.Sdk;
using System;

namespace CPQ.Domain
{
    public class ProductAction
    {
        public string ActionName { get; set; }
        public EntityReference CreatedOn { get; set; }
        public EntityReference Product { get; set; }
        public string FilterValue { get; set; }
        public OptionSetValue Type { get; set; }
        public EntityReference Rule { get; set; }
        public Guid ActionId { get; set; }
        public EntityReference ValueObject { get; set; }
        public EntityReference ValueField { get; set; }
        public EntityReference ValueAttribute { get; set; }
        public bool Required { get; set; }
        public OptionSetValue Operator { get; set; }
        public EntityReference FilterField { get; set; }
        public OptionSetValue Action { get; set; }
    }
}
