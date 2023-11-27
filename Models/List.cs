namespace book_blog_api.Models;

public class List
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    
    public List<Book> Books { get; } = new();
    public List<Tag> Tags { get; } = new();
}