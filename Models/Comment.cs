namespace book_blog_api.Models;

public class Comment
{
    public int id { get; set; }
    public int postId { get; set; }
    public Post post  { get; set; } =  new Post();
    public string name { get; set; } = string.Empty;
    public string comment { get; set; } = string.Empty;
    public DateTime datePosted { get; set; }
}