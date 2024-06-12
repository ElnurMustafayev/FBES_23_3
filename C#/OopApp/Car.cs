namespace OopApp;

class Car
{
    public string Name;
    public double MaxSpeed;
    public double TimeTo100KmInSeconds;
    public double HorsePower;
    private int BeepsCount = 0;

    public void Beep()
    {
        Console.Beep();
        this.BeepsCount++;
    }

    public bool Race(Car anotherCar)
    {
        if(this.TimeTo100KmInSeconds == anotherCar.TimeTo100KmInSeconds)
            return Random.Shared.Next(2) == 1;

        return this.TimeTo100KmInSeconds < anotherCar.TimeTo100KmInSeconds;
    }
}