using Microsoft.EntityFrameworkCore;
using RelationsApp.Entities;
using System.Collections.Generic;

namespace RelationsApp.EntityFramework;

public class RelationsDbContext : DbContext
{
    private const string connectionString = "Server=localhost;Database=RelationsDb;User Id=admin;Password=admin;TrustServerCertificate=True;";
    public DbSet<User> Users { get; set; }

    // - - - one to many - - -
    public DbSet<Post> Posts { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    // - - - many to many - - -
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ArticleTag> ArticlesTags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .HasKey(user => user.MyPrimaryKey);

        modelBuilder
            .Entity<User>()
            .Property(user => user.Name)
            .HasColumnName("Firstname")
            .HasMaxLength(50);

        modelBuilder
            .Entity<User>()
            .Property(user => user.Surname)
            .HasColumnName("Lastname")
            .HasMaxLength(50)
            .HasDefaultValue("Unknown");

        //modelBuilder
        //    .Entity<User>()
        //    .ToTable(tb => tb.HasCheckConstraint("MY_CHECK_CONSTRAINT", "len([Firstname]) > 5"));

        base.OnModelCreating(modelBuilder);
    }
}
