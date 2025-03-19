using Dapper;
using Microsoft.Data.SqlClient;
using MyApp.WebApi.Entities;
using MyApp.WebApi.Repositories.Base;

namespace MyApp.WebApi.Repositories
{
    public class UserSqlRepository : IUserRepository
    {
        private readonly string connectionString;

        public UserSqlRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            var connection = new SqlConnection(connectionString);

            var user = await connection.QueryFirstOrDefaultAsync<User>("select * from Users where Id = @Id", new { Id = id });

            return user;
        }
    }
}