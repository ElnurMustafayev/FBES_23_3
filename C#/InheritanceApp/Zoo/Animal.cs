namespace InheritanceApp.Zoo;

class Animal
{
    protected string name;

    public Animal(string name)
    {
        this.name = name;
    }

    public void Say(string message)
    {
        Console.WriteLine($"{this.name} say: '{message}'");
    }
}