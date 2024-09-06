// 1. dotnet add package Microsoft.EntityFrameworkCore
// 2. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// 3. create DbContext
// 4. override OnConfiguring
// 5. write connectionString

//  6. new MyDbContext().Database.EnsureCreated()

//  6. dotnet tool install --global dotnet-ef
//  7. Microsoft.EntityFrameworkCore.Design
//  8. dotnet-ef migrations add "Add Users"
//  9. dotnet-ef database update

using GettingStartedApp.Data;

var dbcontext = new MyDbContext();
new MyDbContext().Database.EnsureCreated();