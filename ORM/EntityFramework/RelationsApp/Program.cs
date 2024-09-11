using RelationsApp.Entities;
using RelationsApp.EntityFramework;

var dbContext = new RelationsDbContext();
dbContext.Database.EnsureCreated();

//dbContext.Users.Add(new User
//{
//    Mail = "elnur.mustafayeev@gmail.com",
//    Name = "Elnur",
//    Surname = "Mustafayev",
//    Password = "ASGDHASDHFGSAHD123123"
//});

//dbContext.SaveChanges();

//var users = dbContext.Users.ToList();
//foreach (var user in users)
//{
//    Console.WriteLine($"{user.MyPrimaryKey}: {user.Name} {user.Surname}");
//}


/*
var newBlog = new Blog()
{
    Name = "IT"
};

newBlog.Posts.Add(new Post()
{
    Title = "IPhone",
});
newBlog.Posts.Add(new Post()
{
    Title = "Macbook",
});

dbContext.Blogs.Add(newBlog);

dbContext.SaveChanges();
*/



//var post = new Post()
//{
//    Title = "Test",
//    BlogId = 2
//};

//dbContext.Posts.Add(post);
//dbContext.SaveChanges();

//var blog = dbContext.Blogs.First(b => b.Name == "IT");

//var posts = dbContext.Posts
//    .Where(p => p.BlogId == blog.Id)
//    .ToList();

//foreach (var post in posts)
//{
//    Console.WriteLine(post.Title);
//}

/*
dbContext.ArticlesTags.Add(new ArticleTag
{
    Article = new Article
    {
        Title = "My article"
    },
    Tag = new Tag
    {
        Name = "one"
    }
});

dbContext.SaveChanges();
*/