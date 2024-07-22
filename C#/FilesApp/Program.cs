/*
Stream stream = new FileStream("../../../File.txt", FileMode.Append, FileAccess.Write);

for (byte symbol = (byte)'a'; symbol <= (byte)'z'; symbol++)
{
    stream.WriteByte(symbol);
}

stream.Flush();
stream.Flush();
stream.WriteByte((byte)'1');
stream.Flush();
*/



//File.WriteAllText("Test.txt", "File.WriteAllText");
//File.WriteAllText("Test.txt", "File.WriteAllText");

//var text = File.ReadAllText("File.txt");
//Console.WriteLine(text);

//var lines = File.ReadAllLines("File.txt");

//foreach (var line in lines)
//{
//    Console.WriteLine("> " + line);
//}


if(File.Exists("login.txt") == false || File.Exists("password.txt") == false)
{
    Console.Error.WriteLine("Config files not found!");
    return;
}

var login = File.ReadAllText("login.txt");
var password = File.ReadAllText("password.txt");

if(login == "admin" && password == "secret")
{
    Console.WriteLine("Success!");
}
else
{
    Console.WriteLine("Incorrect login or password!");
}