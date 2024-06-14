using PolymorphysmApp.Zoo;

/*
Console.WriteLine(new Animal("Dog").Say());
Console.WriteLine(new Cat("Barsik").Say());
*/


void SaySomething(Animal animal)
{
    Console.WriteLine($"{animal.Name}: {animal.Say()}");
}

SaySomething(new Cat("Barsik"));

//Animal animal = new Cat("Barsik");
//Console.WriteLine(animal.Say());