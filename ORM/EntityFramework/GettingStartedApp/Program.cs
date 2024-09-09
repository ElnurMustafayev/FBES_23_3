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
using GettingStartedApp.Entities;

var dbcontext = new MyDbContext();
new MyDbContext().Database.EnsureCreated();

// UPDATE
if(true) {
    // 1. input search parameter
    System.Console.Write("Input User Id: ");
    var userId = int.Parse(Console.ReadLine() ?? "0");
    // 2. get user by id
    var foundUser = dbcontext.Users.FirstOrDefault(user => user.Id == userId);
    if(foundUser == null) {
        System.Console.WriteLine($"User not found by id '{userId}'!");
        return;
    }
    System.Console.WriteLine($"User by id '{userId}' found!\nInfo: \n{foundUser}");
    // 3. change user's data
    System.Console.Write("New name: ");
    foundUser.Name = Console.ReadLine();
    System.Console.Write("New surname: ");
    foundUser.Surname = Console.ReadLine();
    dbcontext.Users.Update(foundUser);
    // 4. update
    dbcontext.SaveChanges();
    System.Console.WriteLine($"User '{foundUser.Name}' updated successfully!");
}

// SELECT
if(false) {
    var allUsers = dbcontext.Users.ToList();
    System.Console.WriteLine("All users: ");
    foreach (var user in allUsers) {
        System.Console.WriteLine(user);
    }


    // Fluent API
    var isMarriedNotNullUsers = dbcontext.Users
        .Where(user => user.IsMarried != null)
        .Select(user => user.Name)
        .Take(10);

    // select top 10 Name from Users where IsMarried is not null

    // if(false) {
    //     isMarriedNotNullUsers
    //         .Where(t => true);
    // }

    System.Console.WriteLine("Users with IsMarried Data: ");
    foreach (var user in isMarriedNotNullUsers)
    {
        System.Console.WriteLine(user);
    }
}

// DELETE
if(false) {
    var userToDelete = new User {
        Id = 3,
    };

    dbcontext.Users.Remove(userToDelete);
    dbcontext.SaveChanges();
}

// INSERT
if(false) {
    var newUser = new User {
        Name = "Test",
        Surname = "Testov",
        IsMarried = true,
    };

    dbcontext.Users.Add(newUser);

    dbcontext.SaveChanges();
}