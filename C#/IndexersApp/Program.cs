using IndexersApp;

NamesCollection namesCollection = new NamesCollection(new string[]
{
    "Ann",
    "bob",
    "JOHN"
});

namesCollection["john"] = "TEST";

//var name = namesCollection.GetCapitalizedName(index: 2);
var name = namesCollection[2];
Console.WriteLine(name);

/*
var academy = new Academy(new Student[] { ... });
Student student = academy["J11gF7a"];
Console.WriteLine($"{student.Name}: '{student.Fincode}'")
*/