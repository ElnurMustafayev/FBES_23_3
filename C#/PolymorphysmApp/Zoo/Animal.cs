namespace PolymorphysmApp.Zoo;

abstract class Animal
{
    public string Name;

    public Animal(string name)
    {
        this.Name = name;
    }

    public abstract int MyAbstractMethod();

    public virtual string? Say() => null;
}