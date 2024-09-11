namespace RelationsApp.Entities;

// Principal (parent)
public class Blog
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Post> Posts { get; } = new List<Post>(); // Collection navigation containing dependents
}

// Dependent (child)
public class Post
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int BlogId { get; set; } // Required foreign key property
    public Blog Blog { get; set; } = null!; // Required reference navigation to principal
}