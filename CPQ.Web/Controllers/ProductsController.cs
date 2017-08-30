using AutoMapper;
using CodeEffects.Rule.Common;
using CodeEffects.Rule.Core;
using CPQ.Domain;
using CPQ.Persistance.Repositories;
using CPQ.RuleEngine.Models;
using CPQ.Web.Services;
using CPQ.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
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
        public Dictionary<string, List<RuleEvaluationStatus>> Evaluate1(string id)
        {
            List<string> results = new List<string>();
            Dictionary<string, List<RuleEvaluationStatus>> evalResults = new Dictionary<string, List<RuleEvaluationStatus>>();

            // create a dynamic assembly and module 
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "CPQ";
            AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder module = assemblyBuilder.DefineDynamicModule("Domain");

            // create a new type builder
            TypeBuilder typeBuilder = module.DefineType("Product", TypeAttributes.Public | TypeAttributes.Class);


            string propertyName = "Name";

            // Generate a private field
            FieldBuilder field = typeBuilder.DefineField("_" + propertyName, typeof(string), FieldAttributes.Private);
            // Generate a public property
            PropertyBuilder property =
                typeBuilder.DefineProperty(propertyName,
                                 PropertyAttributes.None,
                                 typeof(string),
                                 new Type[] { typeof(string) });

            // The property set and property get methods require a special set of attributes:

            MethodAttributes GetSetAttr =
                MethodAttributes.Public |
                MethodAttributes.HideBySig;

            // Define the "get" accessor method for current private field.
            MethodBuilder currGetPropMthdBldr =
                typeBuilder.DefineMethod("get_value",
                                           GetSetAttr,
                                           typeof(string),
                                           Type.EmptyTypes);

            // Intermediate Language stuff...
            ILGenerator currGetIL = currGetPropMthdBldr.GetILGenerator();
            currGetIL.Emit(OpCodes.Ldarg_0);
            currGetIL.Emit(OpCodes.Ldfld, field);
            currGetIL.Emit(OpCodes.Ret);

            // Define the "set" accessor method for current private field.
            MethodBuilder currSetPropMthdBldr =
                typeBuilder.DefineMethod("set_value",
                                           GetSetAttr,
                                           null,
                                           new Type[] { typeof(string) });

            // Again some Intermediate Language stuff...
            ILGenerator currSetIL = currSetPropMthdBldr.GetILGenerator();
            currSetIL.Emit(OpCodes.Ldarg_0);
            currSetIL.Emit(OpCodes.Ldarg_1);
            currSetIL.Emit(OpCodes.Stfld, field);
            currSetIL.Emit(OpCodes.Ret);

            // Last, we must map the two methods created above to our PropertyBuilder to 
            // their corresponding behaviors, "get" and "set" respectively. 
            property.SetGetMethod(currGetPropMthdBldr);
            property.SetSetMethod(currSetPropMthdBldr);

            // Generate our type
            Type generetedType = typeBuilder.CreateType();

            // Now we have our type. Let's create an instance from it:
            object generetedObject = Activator.CreateInstance(generetedType);

            // Loop over all the generated properties, and assign the values from our XML:
            PropertyInfo[] properties = generetedType.GetProperties();

            // Loop over the values that we will assign to the properties
            string value = "name";
            properties[0].SetValue(generetedObject, value, null);

            string ruleXml = StorageService.LoadRuleXml("a84efa4c-9b31-4822-8c2a-50cb76bbc244");
            //Evaluator<Product> evaluator = new Evaluator<Product>(ruleXml);
            DynamicEvaluator dynamicEvaluator = new DynamicEvaluator(ruleXml);

            var source = GetProduct();

            //bool result1 = evaluator.Evaluate(source);
            bool result2 = dynamicEvaluator.Evaluate(generetedObject);



            return evalResults;
        }

        private Product GetProduct()
        {
            return new Product()
            {
                Name = "name"
            };
        }

        //[HttpGet]
        //public Dictionary<string, List<RuleEvaluationStatus>> Evaluate(string id)
        //{
        //    var products = _repo.All();
        //    var productViewModels = Mapper.Map<IEnumerable<ProductDto>>(products);

        //    List<string> results = new List<string>();
        //    Dictionary<string, List<RuleEvaluationStatus>> evalResults = new Dictionary<string, List<RuleEvaluationStatus>>();

        //    var watch = System.Diagnostics.Stopwatch.StartNew();
        //    var allRules = StorageService.GetEvaluationRules();
        //    foreach (MenuItem rule in allRules)
        //    {
        //        string ruleXml = StorageService.LoadRuleXml(rule.ID);
        //        Evaluator<Product> evaluator = new Evaluator<Product>(ruleXml);
        //        foreach (Product source in products)
        //        {
        //            var sourceKey = source.Id.ToString() + ", Name=" + source.Name;
        //            bool success = evaluator.Evaluate(source);
        //            if (!success)
        //            {
        //                RuleEvaluationStatus status = new RuleEvaluationStatus()
        //                {
        //                    Id = rule.ID,
        //                    ErrorMessage = rule.Description,
        //                    Name = "Failed=" + rule.DisplayName
        //                };
        //                if (evalResults.ContainsKey(sourceKey))
        //                {
        //                    evalResults[sourceKey].Add(status);
        //                }
        //                else
        //                {
        //                    var errorsList = new List<RuleEvaluationStatus>() { status };
        //                    evalResults.Add(sourceKey, errorsList);
        //                }
        //            }
        //            else
        //            {
        //                RuleEvaluationStatus status = new RuleEvaluationStatus()
        //                {
        //                    Id = rule.ID,
        //                    ErrorMessage = "",
        //                    Name = "Passed=" + rule.DisplayName
        //                };
        //                if (evalResults.ContainsKey(sourceKey))
        //                {
        //                    evalResults[sourceKey].Add(status);
        //                }
        //                else
        //                {
        //                    var errorsList = new List<RuleEvaluationStatus>() { status };
        //                    evalResults.Add(sourceKey, errorsList);
        //                }
        //            }
        //            results.Add(string.Format("Product Name={0}, Result = {1}", source.Name, success));
        //        }
        //    }
        //    watch.Stop();
        //    var elapsedMs = watch.ElapsedMilliseconds;
        //    evalResults.Add("TimeTaken", new List<RuleEvaluationStatus> { new RuleEvaluationStatus() { Name = "Time Taken=" + elapsedMs } });
        //    return evalResults;
        //}
    }
}