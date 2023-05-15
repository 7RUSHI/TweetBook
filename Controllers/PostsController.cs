using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Constants.V1;
using TweetBook.Models;
using TweetBook.Options;

namespace TweetBook.Controllers;

[ApiController]
public class PostsController {
    private List<Post> _posts;

    public PostsController(IConfiguration configuration) {
        _posts = new List<Post>();
        for (var i = 0; i < 5; i++) {
            _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
        }


    }

    [HttpGet(ApiRoutes.Posts.GetAll)]
    public IActionResult GetPosts() {
        return new OkObjectResult(_posts);
    }
}
