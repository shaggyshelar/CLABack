using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class TiersViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal LowerBound { get; set; }
        public decimal UpperBound { get; set; }
        public decimal Discountpercent { get; set; }
        public decimal Discountamount { get; set; }
    }
}