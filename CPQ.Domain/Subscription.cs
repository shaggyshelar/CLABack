using Microsoft.Xrm.Sdk;

namespace CPQ.Domain
{
    public class Subscription
    {
        public OptionSetValue SubscriptionPricing { get; set; }
        public string ProductId { get; set; }
        public int SubscriptionTerm { get; set; }
        public OptionSetValue SubscriptionType { get; set; }
    }
}
