namespace OptionsApp.Repositories;

using Microsoft.Extensions.Options;
using OptionsApp.Models;
using OptionsApp.Options;
using OptionsApp.Repositories.Base;

public class ProductSqlRepository : ProductRepositoryBase
{
    private readonly string connectionString;
    private readonly ProductOptions options;

    public ProductSqlRepository(IOptions<ProductOptions> options)
    {
        this.options = options.Value;
        this.connectionString = "Test";
    }

    public override Product GetProductById(int id) {
        System.Console.WriteLine($"Go to sql with connectionstring: {this.connectionString}...");
        // sql ...
        return new Product() {
            Id = id,
        };
    }

    public override void CreateProduct(Product newProduct) {
        System.Console.WriteLine($"Go to sql with connectionstring: {this.connectionString}...");
        // sql ...
    }

    // options
}