using Microsoft.AspNetCore.Mvc;
using WebApiApp.Repositories;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductPostgresRepository repository;

        public ProductController(ProductPostgresRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var product = await repository.GetByIdAsync(id);

                if(product == null) 
                    return base.NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500);
            }
        }
    }
}
