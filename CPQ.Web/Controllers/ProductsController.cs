using CPQ.Domain;
using CPQ.Persistance.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace CPQ.Web.Controllers
{
    public class ProductsController : ApiController
    {
        ProductRepository _repo;

        public ProductsController()
        {
            _repo = new ProductRepository();
        }

        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            var data = _repo.All();
            return data;
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