using Dapper;
using Npgsql;
using WebApiApp.Models;

namespace WebApiApp.Repositories;

public class ProductPostgresRepository
{
    private readonly string connectionString;

    public ProductPostgresRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(this.connectionString);

        var foundProduct = await connection.QueryFirstOrDefaultAsync<Product>(
            sql:    @"select * 
                    from products
                    where id = @id",
            param: new { id });

        return foundProduct;
    }
}
