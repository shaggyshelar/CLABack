using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class SegmentDataViewModel
    {
        public string Type { get; set; }
        public List<ColumnsViewModel> Columns { get; set; }

        public SegmentDataViewModel()
        {
            Columns = new List<ColumnsViewModel>();
        }
    }
}