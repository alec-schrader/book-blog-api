namespace book_blog_api.Models;

public class Post
{
    public int id { get; set; }
    public string title { get; set; } = string.Empty;
    public DateTime date { get; set; }
    public string text { get; set; } = string.Empty;
    public int timesRead { get; set; }

    public ICollection<Book> books { get; set; } = new List<Book>();
    public ICollection<Tag> tags { get; set; } = new List<Tag>();
    public ICollection<Comment> comments { get; set; } = new List<Comment>();
}