namespace DependencyInjectionApp.Repositories;

using DependencyInjectionApp.Repositories.Base;

public class CarBadRepository : ICarRepository
{
    public void BreakCar() => throw new Exception("I'm bad repo");
}