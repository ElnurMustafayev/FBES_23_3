namespace Cqrs.WebApi.Repositories.Base;

using Cqrs.WebApi.Models;

public interface IUserRepository
{
    Task<int> InsertAsync(User user);
}