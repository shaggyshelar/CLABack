using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string QuantityEditable { get; set; }
        public string Description { get; set; }
        public decimal StandardPrice { get; set; }
    }
}