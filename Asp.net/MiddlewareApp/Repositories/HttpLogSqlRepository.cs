namespace MiddlewareApp.Repositories;

using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MiddlewareApp.Models;
using MiddlewareApp.Options;
using MiddlewareApp.Repositories.Base;

public class HttpLogSqlRepository : IHttpLogRepository
{
    private readonly string connectionString;

    public HttpLogSqlRepository(IOptionsSnapshot<DatabaseOptions> options)
    {
        this.connectionString = options.Value.ConnectionString;
    }
    public async Task InsertAsync(HttpLog log)
    {
        using (var connection = new SqlConnection(this.connectionString)) {
            await connection.OpenAsync();

            await connection.ExecuteAsync(
                sql:    $@"INSERT INTO HttpLog (RequestId, RequestUrl, StatusCode, Message)
                        VALUES (@RequestId, @RequestUrl, @StatusCode, @Message);",
                param: log);
        }
    }
}