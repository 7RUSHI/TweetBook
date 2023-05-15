using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Constants.V1;
using TweetBook.Models;
using TweetBook.Options;

namespace TweetBook.Controllers;

[ApiController]
public class PostsController {
    private readonly IConfiguration _configuration;
    private List<Post> _posts;
    public PostsController(IConfiguration configuration) {
        _posts = new List<Post>();
        for (var i = 0; i < 5; i++) {
            _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
        }

        this._configuration = configuration;
    }

    [HttpGet(ApiRoutes.Posts.GetAll)]
    public IActionResult GetPosts() {
        var swaggerOptions = new SwaggerOptions();
        _configuration.GetSection("SwaggerOptions").Bind(swaggerOptions);
        return new OkObjectResult(swaggerOptions);
    }
}
