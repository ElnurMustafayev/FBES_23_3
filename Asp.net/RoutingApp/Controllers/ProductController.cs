namespace RoutingApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using RoutingApp.Models;

// GET: /product/{name}
// GET: /product/{id}
// POST: /product
// DELETE: /product/{id}

// with schemas

[Route("/[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> Products { get; set; } = new List<Product>();

    [Route("{name}")]
    [HttpGet]
    public Product? GetProduct(string name) {
        var foundProduct = Products.FirstOrDefault(product => product.Name == name);
        return foundProduct;
    }

    [Route("{id:int}")]
    [HttpGet]
    public Product? GetProduct(int id) {
        var foundProduct = Products.FirstOrDefault(product => product.Id == id);
        return foundProduct;
    }

    [HttpPost]
    public object CreateProduct([FromBody]Product newProduct) {
        Products.Add(newProduct);
        return newProduct.Id;
    }

    [Route("{id}")]
    [HttpDelete]
    public void DeleteProduct(int id) {
        var foundProduct = Products.FirstOrDefault(product => product.Id == id);

        if(foundProduct != null) {
            Products.Remove(foundProduct);
        }
    }
}