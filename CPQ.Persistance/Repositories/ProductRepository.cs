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
using CPQ.Persistance.Helper;
using CPQ.Persistance.Parsers;

namespace CPQ.Persistance.Repositories
{
    public class ProductRepository : BaseRepository, IGenericRepository<Product>
    {
        ProductParser _parser = new ProductParser();

        public IEnumerable<Product> All()
        {
            string query = string.Format(Constants.Queries.GetProducts, "C0FE4869-0F78-E711-811F-C4346BDC0E01");
            var productCollection = this.FetchExpression(query);
            var products = _parser.Parse(productCollection);
            return products;
        }

        public IEnumerable<Product> Query(string query)
        {
            try
            {
                var productCollection = this.FetchExpression(query);
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public Product FindByKey(Guid id)
        {
            try
            {
                string query = string.Format(Constants.Queries.GetProducts, id);
                var productCollection = this.FetchExpression(query);
            }
            catch (Exception e)
            {
            }

            return null;
        }
    }
}
