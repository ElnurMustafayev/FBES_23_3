using InterfacesApp.Birds.Interfaces;

namespace InterfacesApp.Birds.Models
{
    internal class Duck : IWalkable, IFliable, ISwimmable
    {
        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} fling...");
        }

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
