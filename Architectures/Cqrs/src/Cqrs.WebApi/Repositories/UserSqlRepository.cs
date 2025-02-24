namespace Cqrs.WebApi.Repositories;

using System.Threading.Tasks;
using Cqrs.WebApi.Models;
using Cqrs.WebApi.Repositories.Base;

public class UserSqlRepository : IUserRepository
{
    public Task<int> InsertAsync(User user)
    {
        return Task.FromResult(Random.Shared.Next(100, 1000));
    }
}