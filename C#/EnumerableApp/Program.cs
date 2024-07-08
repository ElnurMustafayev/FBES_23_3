using EnumerableApp;

var students = new Student[]
{
    new("Bob", "Marley"),
    new("Ann", "Brown"),
    new("John", "White"),
};

var academy = new Academy(students);

foreach (var student in academy)
{
    Console.WriteLine(student);
}



/*
 
PhoneBook
    + numbers: PhoneNumber[]
        + person: Person
            + name: string
            + surname: string
            + gender: Gender
        + number: string
 
IEnumerable<PhoneNumber> (with reverse enumeration logic)
IEnumerable<PhoneNumber> (sort by number)
    
output for sorting enumerator:
mr Bob Marley 112365
ms Ann Brown 122435
mr John White 434223
 
*/