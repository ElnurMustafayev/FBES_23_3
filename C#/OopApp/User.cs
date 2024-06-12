namespace OopApp;

class User
{
    public long Id;
    public string Name;
    public string Email;
    //public int Age;
    //public bool IsAdult = false;
    public DateTime? Birthdate;
    public Product[] Products;

    //public User() { }

    public User(long id, string name, string email/*, int age*/)
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        //this.Age = age;
        //this.IsAdult = age >= 18;
    }
}