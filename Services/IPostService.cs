using TweetBook.Models;

namespace TweetBook.Services;
public interface IPostService {
    List<Post> GetPosts();
    Post? GetPostById(Guid postId);
    bool AddPost(Post post);
    bool UpdatePost(Post post);
}
