using ObjectApp;

//var obj1 = 123;
//var obj2 = "text";
//var obj3 = new Book();

//dynamic num = 123;
//num = "asasdasd";
//Console.WriteLine(num.ToUpper());
//Console.WriteLine(num.Imran());
//Console.WriteLine(num.Num);



//object obj1 = 123;
//obj1 = "text";
//obj1 = new Book();
//object obj2 = obj1;



/*
object obj1 = new Book();

string objStr = obj1.ToString();
obj1 = 123;
Console.WriteLine(objStr);
Console.WriteLine(obj1);
*/

/*
object obj1 = new Book();

Type bookType = obj1.GetType();     // info about Book type
Type typeType = bookType.GetType(); // info about Type type
obj1 = typeType.GetType();          // info about Type type

Console.WriteLine(bookType);    // Book
Console.WriteLine(typeType);    // Type
Console.WriteLine(obj1);        // Type
*/

/*
object obj1 = new Book();
object obj2 = obj1;
bool areEqual = obj1.Equals(obj2);

Console.WriteLine(areEqual);

obj2 = new Book();

Console.WriteLine(obj1.Equals(obj2));
*/

/*
object obj1 = new Book();
object obj2 = obj1;
var areEqual = obj1.GetHashCode() == obj2.GetHashCode();

Console.WriteLine(areEqual);
*/




/*
var book = new Book(
    title: "Test",
    author: new Author("Bob", "Marley"),
    pagesCount: 123
    );

//book.PrintInfo();
string bookInfo = book.ToString();
Console.WriteLine(bookInfo);
*/


/*
void MyMethod(object obj)
{
    if(obj.GetType() == typeof(string))
    {
        Console.WriteLine(obj.ToString().ToUpper());
    }
    else if(obj.GetType() == typeof(Author))
    {
        var author = (Author)obj;
        var book = author.WriteBook();
        Console.WriteLine(book);
    }
    else
    {
        Console.WriteLine("ANOTHER TYPE");
    }
}

MyMethod("asdasd");
MyMethod(123);
var author = new Author("Bob", "Marley");
MyMethod(author);
*/



Book GetBook(object obj)
{
    return obj is Author author
        ? author.WriteBook()
        : throw new Exception("SEND AUTHOR!!!");

    //if(obj is Author author)
    //{
    //    return author.WriteBook();
    //}
    //throw new Exception("SEND AUTHOR!!!");


    //if(obj is not Author)
    //{
    //    throw new Exception("SEND AUTHOR!!!");
    //}

    //return (obj as Author)?.WriteBook();// ?? throw new Exception("SEND AUTHOR!!!");

    //return ((Author)obj).WriteBook();
}

//var author = new Author("Bob", "Marley");
//Console.WriteLine(GetBook(author));

GetBook("test");