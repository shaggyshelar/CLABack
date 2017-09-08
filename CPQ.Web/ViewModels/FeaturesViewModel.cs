using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class FeaturesViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public bool DynamicAddEnabled { get; set; }
        public int MinOption { get; set; }
        public int MaxOption { get; set; }
    }
}