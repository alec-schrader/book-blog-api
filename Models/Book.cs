namespace book_blog_api.Models;

public class Book
{
    public int id { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public DateTime publicationDate { get; set; }
    public int rating { get; set; }
    public DateTime readDate { get; set; }
    
    public List<Tag> Tags { get; } = new();
}