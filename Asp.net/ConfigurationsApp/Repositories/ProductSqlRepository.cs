namespace ConfigurationsApp.Repositories;

public class ProductSqlRepository
{
    private readonly string connectionString;

    public ProductSqlRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public object GetProductById(int id) {
        System.Console.WriteLine($"Go to sql with connectionstring: {this.connectionString}...");
        // sql ...
        return new object();
    }
}