using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class SelectValuesViewModel
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
    }
}