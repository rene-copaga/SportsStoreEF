using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    [Route("api/products")]
    public class ProductValuesController : Controller
    {
        private IWebServiceRepository repository;

        public ProductValuesController(IWebServiceRepository repo)
            => repository = repo;

        [HttpGet("{id}")]
        public object GetProduct(long id)
        {
            return repository.GetProduct(id) ?? NotFound();
        }

        [HttpGet]
        public object Products(int skip, int take)
        {
            return repository.GetProducts(skip, take);
        }
    }
}
