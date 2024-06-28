namespace PropertiesApp;

class Person
{
    public const int MinAge = 0;
    public const int MaxAge = 200;

    protected int age;
    protected bool isMarried;

    public void SetIsMarried(bool isMarried)
    {
        if (this.age < 18)
            return;

        this.isMarried = isMarried;
    }

    public void SetAge(string? ageStr)
    {
        if(string.IsNullOrWhiteSpace(ageStr))
        {
            Console.WriteLine("Age can not be empty");
            return;
        }

        bool parsed = int.TryParse(ageStr.Trim(), out int age);

        if (parsed == false)
        {
            Console.WriteLine("Parsing failed!");
            return;
        }

        this.SetAge(age);

        //if (age < Person.MinAge || age > Person.MaxAge)
        //{
        //    Console.WriteLine($"Age must be between {Person.MinAge} and {Person.MaxAge}");
        //    return;
        //}

        //this.Age = age;
    }
    public void SetAge(int age)
    {
        if (age < Person.MinAge || age > Person.MaxAge)
        {
            Console.WriteLine($"Age must be between {Person.MinAge} and {Person.MaxAge}");
            return;
        }

        this.age = age;
    }
    public int GetAge() => this.age;
}

/*
MyClass obj = new MyClass();

obj.SetField(...); // min 1 validation
Console.WriteLine($"Field valud: {obj.GetField()}");
 */