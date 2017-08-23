using CPQ.Common;
using CPQ.Common.Services;
using CPQ.Domain;
using CPQ.Persistance;
using CPQ.Persistance.Configs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CPQ.Web.Controllers
{
    public class ProductsController : ApiController
    {
        private IPropertyMappingService _propertyMappingService;
        ProductRepository _repo;

        public ProductsController()
        {
            //_repo = repo;
            //_propertyMappingService = propertyMappingService;
            //_repo = new GenericRepository<Product>(null);
            _repo = new ProductRepository();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            var data = _repo.All();
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}