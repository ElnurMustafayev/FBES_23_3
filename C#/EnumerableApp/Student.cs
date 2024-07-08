namespace EnumerableApp;

class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Student(string name, string surname)
    {
        this.Name = name;
        this.Surname = surname;
    }

    public override string ToString() => $"{Name} {Surname}";
}
