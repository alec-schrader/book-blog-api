namespace book_blog_api.Models;

public class Book
{
    public int id { get; set; }
    public string title { get; set; } = string.Empty;
    public string author { get; set; } = string.Empty;
    public string genre { get; set; } = string.Empty;
    public DateTime publicationDate { get; set; }
    public string ISBN {  get; set; } = string.Empty;
    public string coverImage { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public string review { get; set; } = string.Empty;
    public int rating { get; set; }
    public DateTime readDate { get; set; }
    public ICollection<Tag> tags { get; set; } = new List<Tag>();
}