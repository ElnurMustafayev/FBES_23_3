namespace PropertiesApp;

class Product
{
    public string Name { get; set; }

    private double price;
    public double Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if(value >= 0)
                this.price = value;
        }
    }

    //public bool IsExpensive => this.Price > 1000;

    //public string Name
    //{
    //    get => this.name;
    //    set => this.name = value;
    //}

    public Product(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }
}