using AutoMapper;
using ESPL.Rule.Core;
using ESPL.Rule.Common;
using CPQ.Domain;
using CPQ.Persistance.Repositories;
using CPQ.RuleEngine.Models;
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
        public Dictionary<string, List<RuleEvaluationStatus>> Evaluate(string id)
        {
            var products = _repo.All();
            var productViewModels = Mapper.Map<IEnumerable<ProductDto>>(products);

            List<string> results = new List<string>();
            Dictionary<string, List<RuleEvaluationStatus>> evalResults = new Dictionary<string, List<RuleEvaluationStatus>>();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var allRules = StorageService.GetEvaluationRules();
            foreach (MenuItem rule in allRules)
            {
                string ruleXml = StorageService.LoadRuleXml(rule.ID);
                Evaluator<Product> evaluator = new Evaluator<Product>(ruleXml);
                foreach (Product source in products)
                {
                    var sourceKey = source.Id.ToString() + ", Name=" + source.Name;
                    bool success = evaluator.Evaluate(source);
                    if (!success)
                    {
                        RuleEvaluationStatus status = new RuleEvaluationStatus()
                        {
                            Id = rule.ID,
                            ErrorMessage = rule.Description,
                            Name = "Failed=" + rule.DisplayName
                        };
                        if (evalResults.ContainsKey(sourceKey))
                        {
                            evalResults[sourceKey].Add(status);
                        }
                        else
                        {
                            var errorsList = new List<RuleEvaluationStatus>() { status };
                            evalResults.Add(sourceKey, errorsList);
                        }
                    }
                    else
                    {
                        RuleEvaluationStatus status = new RuleEvaluationStatus()
                        {
                            Id = rule.ID,
                            ErrorMessage = "",
                            Name = "Passed=" + rule.DisplayName
                        };
                        if (evalResults.ContainsKey(sourceKey))
                        {
                            evalResults[sourceKey].Add(status);
                        }
                        else
                        {
                            var errorsList = new List<RuleEvaluationStatus>() { status };
                            evalResults.Add(sourceKey, errorsList);
                        }
                    }
                    results.Add(string.Format("Product Name={0}, Result = {1}", source.Name, success));
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            evalResults.Add("TimeTaken", new List<RuleEvaluationStatus> { new RuleEvaluationStatus() { Name = "Time Taken=" + elapsedMs } });
            return evalResults;
        }
    }
}