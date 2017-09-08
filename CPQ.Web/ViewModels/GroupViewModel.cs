using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class GroupViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? SsOptional { get; set; }
        public string Description { get; set; }
        public double? Additionaldiscount { get; set; }
        public decimal? SubscriptionTerm { get; set; }
    }
}