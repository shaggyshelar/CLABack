using AutoMapper;
using ESPL.Rule.Core;
using CPQ.Domain;
using CPQ.Persistance.Repositories;
using CPQ.Web.Services;
using CPQ.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CPQ.Web.Controllers
{
    public class ProductsController : ApiController
    {
        ProductRepository _repo = new ProductRepository();

        //public IEnumerable<Product> Get()
        public IEnumerable<ProductDto> Get()
        {
            var products = _repo.All();
            var productViewModels = Mapper.Map<IEnumerable<ProductDto>>(products);
            return productViewModels;
        }

        [HttpGet]
        public List<string> Evaluate(string id)
        {
            var products = _repo.All();
            var productViewModels = Mapper.Map<IEnumerable<ProductDto>>(products);

            List<string> results = new List<string>();
            string ruleXml = StorageService.LoadRuleXml(id);
            Evaluator<Product> evaluator = new Evaluator<Product>(ruleXml);
            foreach (Product source in products)
            {
                bool success = evaluator.Evaluate(source);
                results.Add(string.Format("Product Name={0}, Result = {1}", source.Name, success));
            }
            return results;
        }
    }
}