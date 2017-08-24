using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPQ.Domain;
using CPQ.Common;
using CPQ.Persistance.Configs;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace CPQ.Persistance
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private OrganizationService _orgService;
        private CrmConnection _connection;
        CRMConfiguration config = new CRMConfiguration();

        public IEnumerable<Product> All()
        {
            _connection = CrmConnection.Parse(config.GetURL());
            try
            {
                using (_orgService = new OrganizationService(_connection))
                {
                    string query = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                          <entity name='product'>
                            <attribute name='name' />
                            <attribute name='productid' />
                            <attribute name='productnumber' />
                            <attribute name='description' />
                            <attribute name='statecode' />
                            <attribute name='productstructure' />
                            <attribute name='p2qes_defaultquantity' />
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
                                <condition attribute='pricelevelid' operator='eq' uitype='pricelevel' value='EE8EAC6F-0F78-E711-811F-C4346BDC0E01' />" +
                              @"</filter>
                            </link-entity>
                          </entity>
                        </fetch>";

                    var fetchExpression = new FetchExpression(Convert.ToString(query));
                    EntityCollection ProductDataCollection = _orgService.RetrieveMultiple(fetchExpression);
                    //List<ProductDataModel> ProductDataColln = new List<ProductDataModel>();
                }
            }
            catch (Exception e)
            {
            }

            return null;
        }

        public IEnumerable<Product> Query(string query)
        {
            throw new NotImplementedException();
        }

        public bool EntityExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> AllInclude(params System.Linq.Expressions.Expression<Func<Product, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindBy(System.Linq.Expressions.Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindByInclude(System.Linq.Expressions.Expression<Func<Product, bool>> predicate, params System.Linq.Expressions.Expression<Func<Product, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Product FindByKey(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
