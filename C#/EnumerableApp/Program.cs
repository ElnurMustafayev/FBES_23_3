using EnumerableApp;

var students = new Student[]
{
    new("Bob", "Marley"),
    new("Ann", "Brown"),
    new("John", "White"),
};

var enumerable = new AcademyEnumerator(students);

var academy = new Academy(students, enumerable);

foreach (var student in academy)
{
    Console.WriteLine(student);
}






/*
var students = new Student[]
{
    new("Bob", "Marley"),
    new("Ann", "Brown"),
    new("John", "White"),
};

var academy = new Academy(students);

var academyEnumerator = academy.GetEnumerator();

while(academyEnumerator.MoveNext())
{
    var item = academyEnumerator.Current;
}
academyEnumerator.Reset();

foreach (var student in academy)
{
    Console.WriteLine(student);
}
*/

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