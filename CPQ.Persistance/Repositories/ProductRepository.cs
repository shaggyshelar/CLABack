using System;
using System.Collections.Generic;
using System.Linq;
using CPQ.Domain;
using CPQ.Common;
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
            return _parser.Parse(productCollection);
        }

        public IEnumerable<Product> Query(string query)
        {
            var productCollection = this.FetchExpression(query);
            return _parser.Parse(productCollection);
        }

        public Product FindByKey(Guid id)
        {
            //TODO: Modify the query to get first product matching with GUID
            string query = string.Format(Constants.Queries.GetProducts, id);
            var productCollection = this.FetchExpression(query);
            return _parser.Parse(productCollection).FirstOrDefault();
        }
    }
}
