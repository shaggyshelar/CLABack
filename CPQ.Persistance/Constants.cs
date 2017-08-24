using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Persistance
{
    public static class Constants
    {
        public static class Queries
        {
            public const string GetProducts = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                          <entity name='product'>
                            <attribute name='name' alias = 'Name' />
                            <attribute name='productid' alias = 'Id' />
                            <attribute name='productnumber' alias='ProductCode' />
                            <attribute name='description'  alias='Description'/>
                            <attribute name='statecode' />
                            <attribute name='productstructure'  alias='ProductStrucuture' />
                            <attribute name='p2qes_defaultquantity' />
                             <attribute name='standardcost'  alias='StandardPrice' />
                                <attribute name='p2qes_discountlist'  alias='DiscountList' />

                            <attribute name='p2qes_quantityeditable' />
                            <order attribute='productnumber' descending='false' />
                            <filter type='and'>
                              <condition attribute='name' operator='not-null' />
                            </filter>
                            <link-entity name='productpricelevel' from='productid' to='productid'>
                               <attribute name='amount' />
                                <attribute name='pricingmethodcode' />
                                <attribute name='pricelevelid' />
                              <filter type='and'>
                                <condition attribute='pricelevelid' operator='eq' uitype='pricelevel' value='{0}' />" +
                              @"</filter>
                            </link-entity>
                          </entity>
                        </fetch>";
        }
    }
}
