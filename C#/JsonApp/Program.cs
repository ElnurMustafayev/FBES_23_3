using JsonApp;
using System.Text.Json;

/*
var user1 = new User
{
    Id = 1,
    Name = "Bob",
    Surname = "Marley",
};

var user2 = new User
{
    Id = 2,
    Name = "Ann",
    Surname = "Marley",
};

user1.Partner = user2;
//user2.Partner = user1;

var userJson = JsonSerializer.Serialize(user1);
Console.WriteLine(userJson);

File.WriteAllText("users.json", userJson);
*/



//var userJson = File.ReadAllText("users.json");
//var user = JsonSerializer.Deserialize<User>(userJson);

//Console.WriteLine(user);




/*
var users = new List<User>
{
    new User {
        Id = 1,
        Name = "Bob",
        Surname = "Marley",
    },
    new User {
        Id = 2,
        Name = "Ann",
        Surname = "Brown",
    }
};

var usersJson = JsonSerializer.Serialize(users);

File.WriteAllText("users.json", usersJson);
*/


var usersJson = File.ReadAllText("users.json");
var users = JsonSerializer.Deserialize<List<User>>(usersJson);

users.Add(new User
{
    Id = 3,
    Name = "Elnur",
    Surname = "Mustafayev",
});

var usersJsonWithNewUser = JsonSerializer.Serialize(users);
File.WriteAllText("users.json", usersJsonWithNewUser);

// sql 



// file