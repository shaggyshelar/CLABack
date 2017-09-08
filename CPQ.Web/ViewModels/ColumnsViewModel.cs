using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class ColumnsViewModel
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Uplift { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal AdditionalDiscount { get; set; }
        public decimal NetunitPrice { get; set; }
        public decimal NetTotal { get; set; }
        public bool IsDefault { get; set; }
    }
}