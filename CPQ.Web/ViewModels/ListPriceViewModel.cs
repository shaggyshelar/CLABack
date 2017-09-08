using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class ListPriceViewModel
    {
        public decimal Value { get; set; }
        public bool IsEditable { get; set; }
        public bool IsVisible { get; set; }
        public decimal DataType { get; set; }
        public List<SelectValuesViewModel> SelectValues { get; set; }

        public ListPriceViewModel()
        {
            SelectValues = new List<SelectValuesViewModel>();
        }

    }
}