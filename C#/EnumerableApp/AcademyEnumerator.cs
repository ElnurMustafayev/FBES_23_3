using System.Collections;

namespace EnumerableApp;

/*
class AcademyEnumerator : IEnumerator
{
    private const int counterStartValue = -1;
    private int counter = counterStartValue;
    private readonly object[] students;

    public object Current => this.students[counter];

    public AcademyEnumerator(object[] students)
    {
        this.students = students;
    }

    public bool MoveNext()
    {
        //Console.WriteLine("Counter: " + ++counter);

        counter++;

        if (counter >= this.students.Length)
        {
            this.Reset();
            return false;
        }

        return true;
    }

    public void Reset()
    {
        this.counter = counterStartValue;
    }
}
*/



class AcademyEnumerator : IEnumerator<Student>
{
    private const int counterStartValue = -1;
    private int counter = counterStartValue;
    private readonly Student[] students;

    public Student Current => this.students[counter];

    object IEnumerator.Current => this.students[counter];

    public AcademyEnumerator(Student[] students)
    {
        this.students = students;
    }

    public void Dispose() { }

    public bool MoveNext()
    {
        this.counter++;

        if(this.counter >= this.students.Length)
        {
            this.Reset();
            return false;
        }

        return true;
    }

    public void Reset()
    {
        this.counter = counterStartValue;
    }
}