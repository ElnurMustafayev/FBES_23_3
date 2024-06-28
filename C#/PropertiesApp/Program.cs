using PropertiesApp;

/*
Person person = new Person();

//Console.Write("Please enter your age: ");
//person.SetAge(Console.ReadLine());

person.SetAge(55);

Console.WriteLine($"Age: {person.GetAge()}");
*/



Product product = new Product(name: "IPhone 15", price: 1200);

Console.WriteLine(product.Name);
product.Name = "Banana";
Console.WriteLine(product.Name);