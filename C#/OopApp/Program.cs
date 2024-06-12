using OopApp;

/*
//var myClass = new OopApp.MyClass();
MyClass myClass = new MyClass();

myClass.num = 123;

Console.WriteLine(myClass.num);
*/

/*
User user = new User(
    id: 777,
    name: "Bob",
    email: "bob@gmail.com");

Console.WriteLine($"#{user.Id}: {user.Name?.Normalize()}, {user.Email}");
*/



// ctor(2 parameters) { // init 3 fields }

/*
//DateTime dateTime = new DateTime();
//DateTime dateTime = new DateTime(year: 2024, month: 8, day: 5);
DateTime dateTime = DateTime.Now;

Console.WriteLine(dateTime);
Console.WriteLine($"Year: {dateTime.Year}");
Console.WriteLine($"Month: {dateTime.Month}");
Console.WriteLine($"Day: {dateTime.Day}");
Console.WriteLine($"DayOfWeek: {dateTime.DayOfWeek}");
Console.WriteLine($"DayOfYear: {dateTime.DayOfYear}");
Console.WriteLine($"Hour: {dateTime.Hour}");
Console.WriteLine($"Minute: {dateTime.Minute}");
Console.WriteLine($"Second: {dateTime.Second}");
Console.WriteLine($"Millisecond: {dateTime.Millisecond}");
*/

//User GetBob() => new User(123, "Bob", "bob@gmail.com")
//{
//    Birthdate = new DateTime(1965, 5, 5),
//};

/*
User GetBob()
{
    var user = new User(123, "Bob", "bob@gmail.com");
    user.Birthdate = new DateTime(1965, 5, 5);
    return user;
}
*/

/*
User GetBob()
{
    var user = new User(123, "Bob", "bob@gmail.com")
    {
        Birthdate = new DateTime(1965, 5, 5),
    };

    return user;
}
*/



//new Product(123, "test", 5.5);

//Parameterless ctor
//Parameterize ctor
//Parameterless ctor


/*
User user = new User(123, "Bob", "bob@gmail.com")
{
    Products = new Product[]
    {
        new Product(555, "Iphone 15", 1500),
        new Product(200, "TV", 500),
        new Product(142, "Cola", 2),
    }
};

Console.WriteLine(user.Products[2].Name);
*/



/*
var car1 = new Car
{
    Name = "Porsche",
    MaxSpeed = 360,
    HorsePower = 440,
    TimeTo100KmInSeconds = 4.5
};
//car1.Beep();

var car2 = new Car
{
    Name = "Mercedes",
    MaxSpeed = 320,
    HorsePower = 380,
    TimeTo100KmInSeconds = 6
};
//car2.Beep();

bool raceResult = car2.Race(car1);
Console.WriteLine(raceResult);
*/