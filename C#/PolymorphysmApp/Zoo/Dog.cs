namespace PolymorphysmApp.Zoo;

class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override string? Say() => "huf";

    public override int MyAbstractMethod() => 777;
}

class Xatiko : Dog
{
    public Xatiko(string name) : base(name) { }
}
