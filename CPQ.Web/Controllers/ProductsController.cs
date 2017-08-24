using AutoMapper;
using CodeEffects.Rule.Core;
using CPQ.Domain;
using CPQ.Persistance.Repositories;
using CPQ.Web.Services;
using CPQ.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace CPQ.Web.Controllers
{
    public class ProductsController : ApiController
    {
        ProductRepository _repo = new ProductRepository();

        //public IEnumerable<Product> Get()
        public List<string> Get()
        {
            var products = _repo.All();
            var productViewModels = Mapper.Map<IEnumerable<ProductDto>>(products);

            List<string> results = new List<string>();
            string ruleXml = StorageService.LoadRuleXml("ee5283a5-e529-441e-9621-368492d942c1");
            Evaluator<Product> evaluator = new Evaluator<Product>(ruleXml);
            //bool allResults = products.Evaluate(ruleXml);
            foreach (Product source in products)
            {
                bool success = evaluator.Evaluate(source);
                results.Add(string.Format("Product Name={0}, Result = {1}", source.Name, success));
            }
            return results;
        }

        public void Evaluate()
        {
            var data = _repo.All();
        }
    }
}