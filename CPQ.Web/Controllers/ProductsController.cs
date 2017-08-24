using AutoMapper;
using CPQ.Domain;
using CPQ.Persistance.Repositories;
using CPQ.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace CPQ.Web.Controllers
{
    public class ProductsController : ApiController
    {
        ProductRepository _repo = new ProductRepository();

        public IEnumerable<Product> Get()
        {
            var data = _repo.All();
            var productViewModels = Mapper.Map<IEnumerable<ProductDto>>(data);
            return data;
        }
    }
}