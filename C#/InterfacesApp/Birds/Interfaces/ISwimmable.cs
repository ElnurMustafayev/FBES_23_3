using InterfacesApp.Birds.Interfaces;

namespace InterfacesApp.Birds.Interfaces
{
    internal interface ISwimmable
    {
        void Swim();

        void SomethingDefault()
        {
            Console.WriteLine("Default");
        }
    }
}

class A : ISwimmable
{
    public void Swim()
    {
        Console.WriteLine("swim A");
    }
}

class B : ISwimmable
{
    public void Swim()
    {
        Console.WriteLine("swim B");
    }
}

class C : B
{
    public new void Swim()
    {
        Console.WriteLine("swim C");
    }
}