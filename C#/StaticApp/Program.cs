using StaticApp;

User user1 = new User("Bob");
Console.WriteLine($"Id: {user1.UserId.Id}");
Console.WriteLine($"Name: {user1.Name}");
Console.WriteLine($"CreationDate: {user1.CreationDate}");

User user2 = new User("Ann");
Console.WriteLine($"Id: {user2.UserId.Id}");
Console.WriteLine($"Name: {user2.Name}");
Console.WriteLine($"CreationDate: {user2.CreationDate}");