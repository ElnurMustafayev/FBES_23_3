namespace MiddlewareApp.Options;

public class DatabaseOptions
{
    public string ConnectionString { get; set; }

    public DatabaseOptions(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    public DatabaseOptions()
    {
        this.ConnectionString = string.Empty;
    }
}