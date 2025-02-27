namespace FilesApp.Entities;

public class User
{
    public Guid Uid { get; set; }
    public string? Mail { get; set; }
    public required string Name { get; set; }
}