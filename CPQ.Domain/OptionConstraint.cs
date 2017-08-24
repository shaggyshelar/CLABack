using Microsoft.Xrm.Sdk;
using System;

namespace CPQ.Domain
{
    public class OptionConstraint
    {
        public Guid ConstraintId { get; set; }
        public string ConstraintName { get; set; }
        public EntityReference ConstrainedOption { get; set; }
        public EntityReference ConstrainingOption { get; set; }
        public EntityReference ConfiguredSKU { get; set; }
        public OptionSetValue Type { get; set; }
        public bool IsActive { get; set; }
    }
}
