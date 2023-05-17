using TweetBook.Models;

namespace TweetBook.Services {
    public class PostService : IPostService {
        private readonly List<Post> posts;

        public PostService() {
            posts = new List<Post>();
        }

        public Post? GetPostById(Guid postId) {
            return posts.SingleOrDefault(p => p.Id == postId);
        }

        public List<Post> GetPosts() {
            return posts;
        }

        public bool AddPost(Post post) {
            posts.Add(post);
            return true;
        }
    }
}
