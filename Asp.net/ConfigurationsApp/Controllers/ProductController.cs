using ConfigurationsApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductSqlRepository repository;

        public ProductController(ProductSqlRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id) {
            var result = this.repository.GetProductById(id);

            return Ok(result);
        }
    }
}