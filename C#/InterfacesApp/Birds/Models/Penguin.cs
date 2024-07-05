using InterfacesApp.Birds.Interfaces;

namespace InterfacesApp.Birds.Models
{
    internal class Penguin : IWalkable, ISwimmable //IBird
    {
        public void Swim()
        {
            Console.WriteLine($"{this.GetType().Name} swimming...");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} walking...");
        }
    }
}
