namespace OopApp;

public class Product
{
    public long Id;
    public string Name;
    public string Description;
    public double Price;

    public Product()
    {
        Console.WriteLine("Parameterless ctor");
        this.Id = 0;
        this.Name = "Unknown";
        this.Description = "Nothing";
        this.Price = 0.0;
    }

    public Product(long id, string name, double price) : this()
    {
        Console.WriteLine("Parameterize ctor");
        this.Id = id;
        this.Name = name;
        this.Price = price;

        new Product();
    }
}