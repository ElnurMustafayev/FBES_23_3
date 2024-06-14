namespace PolymorphysmApp.Zoo;

class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override string? Say() => "meow";

    public override int MyAbstractMethod() => 100;
}