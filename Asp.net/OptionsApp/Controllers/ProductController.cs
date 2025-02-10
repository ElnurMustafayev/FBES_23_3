namespace OptionsApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsApp.Models;
using OptionsApp.Options;
using OptionsApp.Repositories.Base;

public class ProductController : Controller
{
    private readonly ProductRepositoryBase repository;
    private readonly ProductOptions options;

    public ProductController(ProductRepositoryBase repository, IOptionsSnapshot<ProductOptions> options)
    {
        this.options = options.Value;
        this.repository = repository;
    }

    [HttpGet("/api/[controller]/{id}")]
    public ActionResult<Product> GetProduct(int id) {
        var result = this.repository.GetProductById(id);

        return Ok(result);
    }

    [HttpGet("/[controller]/[action]")]
    public ActionResult Index() {
        base.ViewBag.CardBorderRadiusPx = this.options.CardBorderRadiusPx;
        return base.View();
    }
}