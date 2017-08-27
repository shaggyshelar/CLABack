using AutoMapper;
using CodeEffects.Rule.Common;
using CodeEffects.Rule.Core;
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
        public Dictionary<string, List<string>> Evaluate(string id)
        {
            var products = _repo.All();
            var productViewModels = Mapper.Map<IEnumerable<ProductDto>>(products);

            List<string> results = new List<string>();
            Dictionary<string, List<string>> evalResults = new Dictionary<string, List<string>>();

            var allRules = StorageService.GetEvaluationRules();
            foreach (MenuItem rule in allRules)
            {
                string ruleXml = StorageService.LoadRuleXml(rule.ID);
                Evaluator<Product> evaluator = new Evaluator<Product>(ruleXml);
                foreach (Product source in products)
                {
                    bool success = evaluator.Evaluate(source);
                    if (!success)
                    {
                        var errorMessage = "Failed: " + rule.ID + ", Name=" + source.Name;
                        if (evalResults.ContainsKey(source.Id.ToString()))
                        {
                            evalResults[source.Id.ToString()].Add(errorMessage);
                        }
                        else
                        {
                            var errorsList = new List<string>() { errorMessage };
                            evalResults.Add(source.Id.ToString(), errorsList);
                        }
                    }
                    results.Add(string.Format("Product Name={0}, Result = {1}", source.Name, success));
                }
            }
            return evalResults;
        }
    }
}