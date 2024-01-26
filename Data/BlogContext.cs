using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using book_blog_api.Models;
using Microsoft.Extensions.Options;

public class BlogContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public BlogContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //book -> booktag -> tag many-to-many relationship
        modelBuilder.Entity<Book>()
            .HasMany(b => b.tags)
            .WithMany();

        //post -> posttag -> tag many-to-many relationship
        modelBuilder.Entity<Post>()
            .HasMany(b => b.tags)
            .WithMany();

    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=db.db").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

}