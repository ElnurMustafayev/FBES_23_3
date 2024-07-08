using InterfacesApp;
using InterfacesApp.Birds.Interfaces;
using InterfacesApp.Birds.Models;
using InterfacesApp.Interfaces;

/*
MyClass myClass = new MyClass();
Console.WriteLine(myClass.Name);

IFirstInterface obj1 = new MyClass();
//obj1.MyMethodWithBody();
obj1.Method();

ISecondInterface obj2 = new MyClass();
Console.WriteLine(obj2.Name);


ISecondInterface obj = new B();
obj.Method();
*/


/*
Duck duck = new Duck();
duck.Fly();
duck.Walk();
duck.Swim();

Penguin penguin = new Penguin();
penguin.Walk();
//penguin.Fly();
penguin.Swim();

Parrot parrot = new Parrot();
parrot.Walk();
parrot.Fly();


IFliable[] fliables =
{
    duck, parrot
};
*/

/*
ISwimmable[] swimmables =
{
    new A(), new B(), new C()
};

foreach (var swimmable in swimmables)
{
    swimmable.Swim();
    swimmable.SomethingDefault();
}
*/

//new C().Swim();

ISwimmable obj = new C();
obj.Swim();