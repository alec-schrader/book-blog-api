using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using book_blog_api.Models;

public class BlogContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<List> Lists { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public string DbPath { get; }

    public BlogContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}