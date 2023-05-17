namespace TweetBook.Models;
public class Post {
    public required Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
