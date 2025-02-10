namespace OptionsApp.Repositories.Base;

using OptionsApp.Models;

public abstract class ProductRepositoryBase
{
    public abstract Product GetProductById(int id);
    public abstract void CreateProduct(Product newProduct);
}