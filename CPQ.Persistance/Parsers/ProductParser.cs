using CPQ.Domain;
using CPQ.Persistance.Helper;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Persistance.Parsers
{
    public class ProductParser : IEntityParser<Product>
    {
        public IEnumerable<Product> Parse(EntityCollection collection)
        {
            var products = new List<Product>();
            if (collection != null && collection.Entities.Count > 0)
            {
                foreach (Entity ProductDataItem in collection.Entities)
                {
                    Product model = new Product();
                    DataMapper.MapObject(model, ProductDataItem.Attributes);
                    switch (model.ProductStrucuture)
                    {
                        case "1":
                            model.ProductStrucuture = "Product";
                            break;
                        case "2":
                            model.ProductStrucuture = "ProductFamily";
                            break;
                        case "3":
                            model.ProductStrucuture = "ProductBundle";
                            break;
                    }
                    model.DefaultQuantity = ProductDataItem.Contains("p2qes_defaultquantity") ? ProductDataItem.Attributes["p2qes_defaultquantity"].ToString() : "";
                    model.QuantityEditable = ProductDataItem.Contains("p2qes_quantityeditable") ? ProductDataItem.Attributes["p2qes_quantityeditable"].ToString() : "";
                    products.Add(model);
                }
            }

            return products;
        }
    }
}
