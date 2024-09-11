namespace RelationsApp.Entities;

public class Article
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public List<ArticleTag> ArticleTags { get; } = [];
}

public class Tag
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<ArticleTag> ArticleTags { get; } = [];
}

public class ArticleTag
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public int TagId { get; set; }
    public Article Article { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
