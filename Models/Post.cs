namespace book_blog_api.Models;

public class Post
{
    public int id { get; set; }
    public string title { set; get; }
    public DateTime date { set; get; }
    public string text { set; get; }
    public int timesRead { set; get; }
    
    public List<Book> Books { get; } = new();
    public List<Tag> Tags { get; } = new();
}