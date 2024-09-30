using AttributesApp;

void Print<T>(T obj)
{
    foreach (var propInfo in typeof(T).GetProperties())
    {
        if (propInfo.CustomAttributes.FirstOrDefault(attr => attr.AttributeType == typeof(InvisibleAttribute)) != null)
            continue;

        Console.WriteLine($"{propInfo.Name}: {propInfo.GetValue(obj)}");
    }
}

var user = new User()
{
    Name = "Bob",
    Surname = "Marley",
};

Print(user);