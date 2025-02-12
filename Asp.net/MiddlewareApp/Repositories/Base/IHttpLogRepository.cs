using MiddlewareApp.Models;

namespace MiddlewareApp.Repositories.Base;

public interface IHttpLogRepository
{
    public Task InsertAsync(HttpLog log);
}