using System.Collections;

namespace EnumerableApp;

class Academy : IEnumerable<Student> /*IEnumerable*/
{
    private IEnumerator<Student> enumerator;
    public Student[] Students { get; private set; }

    public Academy(Student[] students, IEnumerator<Student> enumerator)
    {
        this.Students = students;
        this.enumerator = enumerator;
    }

    public IEnumerator<Student> GetEnumerator() => this.enumerator;

    IEnumerator IEnumerable.GetEnumerator() => this.enumerator;
}
