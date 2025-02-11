namespace MiddlewareApp.Services;

using Microsoft.Extensions.Options;
using MiddlewareApp.Services.Base;
using Microsoft.Data.SqlClient;
using Dapper;
using MiddlewareApp.Options;

public class TestService : ITestService
{
    private readonly string connectionString;

    public TestService(IOptionsSnapshot<DatabaseOptions> options)
    {
        this.connectionString = options.Value.ConnectionString;
    }

    public void NeverCrashes() {
        throw new Exception("Oups, I crashed!");
    }

    public void DontPutNull(string? text) {
        ArgumentNullException.ThrowIfNull(text);
    }

    public async Task GoToDatabaseAsync() {
        var connection = new SqlConnection(this.connectionString);

        await connection.OpenAsync();

        var affectedRowsCount = connection.Execute(sql: @"select 10;");
    }
}