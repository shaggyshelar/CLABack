using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class ConfigurationAttribute
    {
        public string AttributeName { get; set; }
        public EntityReference ProudctId { get; set; }
        public string TargetField { get; set; }
        public string RowOrder { get; set; }
        public OptionSetValue ColumnOrder { get; set; }
        public OptionSetValue Position { get; set; }
        public EntityReference Feature { get; set; }
        public bool AutoSelect { get; set; }
        public bool ApplyImmediately { get; set; }
    }
}
