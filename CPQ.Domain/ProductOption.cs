using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class ProductOption
    {
        public int Number { get; set; }
        public Guid ProductAssociationId { get; set; }

        public decimal Quantity { get; set; }
        public bool IsQuantityEditable { get; set; }

        public EntityReference Feature { get; set; }
        public EntityReference Category { get; set; }

        public OptionSetValue Type { get; set; }
        public bool IsSelected { get; set; }
        public OptionSetValue IsRequired { get; set; }
        public bool IsBundled { get; set; }
        public bool IsPriceEditable { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public int UnitPrice { get; set; }
        public EntityReference Units { get; set; }
        public int DiscountPercent { get; set; }
        public EntityReference DiscountSchedule { get; set; }
        public int DiscountAmt { get; set; }


        public EntityReference Bundle { get; set; }
        public EntityReference AssociatedProduct { get; set; }
    }
}
