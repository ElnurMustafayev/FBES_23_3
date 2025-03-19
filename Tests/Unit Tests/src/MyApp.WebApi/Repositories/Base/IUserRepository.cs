using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.WebApi.Entities;

namespace MyApp.WebApi.Repositories.Base;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(int id);
}