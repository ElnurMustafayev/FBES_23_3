namespace InheritanceApp.Zoo;

class Cat : Animal
{
    public int lifesCount = 9;
    private int currentLife = 9;

    //public Cat() : base("Cat") {}
    public Cat(string nickname) : base(name: nickname) { }

    public void Lick()
    {
        Console.WriteLine($"{base.name} is licking...");
    }
}