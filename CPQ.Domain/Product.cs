using CPQ.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Domain
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string ProductStrucuture { get; set; }
        public string DefaultQuantity { get; set; }
        public string SubscriptionType { get; set; }
        public string SubscriptionPricing { get; set; }
        public string QuantityEditable { get; set; }
        public string PriceEditable { get; set; }
    }
}
