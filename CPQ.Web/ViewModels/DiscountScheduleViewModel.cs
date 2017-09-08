using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class DiscountScheduleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DiscountUnit { get; set; }
        public string Type { get; set; }
        public List<TiersViewModel> Tiers { get; set; }

        public DiscountScheduleViewModel()
        {
            Tiers = new List<TiersViewModel>();
        }
    }
}