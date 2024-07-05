using InterfacesApp.Birds.Interfaces;

namespace InterfacesApp.Birds.Models
{
    internal class Parrot : IWalkable, IFliable //IBird
    {
        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} fling...");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} walking...");
        }
    }
}
