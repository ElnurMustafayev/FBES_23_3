using System.Data.SqlClient;

string connectionString = "Server=localhost;Database=MyDatabase;User Id=admin;Password=admin;";

var connection = new SqlConnection(connectionString);
connection.Open();

System.Console.WriteLine(@"Press key to continue:
1 - add new teacher
2 - get teachers' count" + Environment.NewLine);

var pressedKey = Console.ReadKey().Key;
Console.Clear();

if(pressedKey == ConsoleKey.D1) {
    Console.WriteLine("New teacher's creating\n");
    Console.Write("Input name: ");
    var newTeacherName = Console.ReadLine();
    Console.Write("Input salary: ");
    double.TryParse(Console.ReadLine(), out double newTeacherSalary);
    Console.Write("Input country: ");
    var newTeacherCountry = Console.ReadLine();

    var command = new SqlCommand(
        cmdText: @$"insert into Teachers ([Name], [Salary], [CountryId]) 
        values	('{newTeacherName}', {newTeacherSalary}, {newTeacherCountry})",
        connection: connection
    );

    int affectedRowsCount = command.ExecuteNonQuery();

    if(affectedRowsCount > 0) {
        System.Console.WriteLine($"Teacher '{newTeacherName}' was added successfully!");
    }
}
else if(pressedKey == ConsoleKey.D2) {
    var command = new SqlCommand(
        cmdText: "select count(*) from Teachers",
        connection: connection
    );

    object result = command.ExecuteScalar();

    System.Console.WriteLine($"Teachers' count: {result}");
}
else {
    System.Console.WriteLine($"No implementation for '{pressedKey}'!");
}