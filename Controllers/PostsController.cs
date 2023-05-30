using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts.V1;
using TweetBook.Contracts.V1.Requests;
using TweetBook.Contracts.V1.Responses;
using TweetBook.Models;
using TweetBook.Options;
using TweetBook.Services;

namespace TweetBook.Controllers;

[ApiController]
public class PostsController : ControllerBase {
    private readonly IPostService _postService;

    public PostsController(IPostService postService) {
        this._postService = postService;
    }

    [HttpGet(ApiRoutes.Posts.GetAll)]
    public IActionResult GetAll() {
        return Ok(_postService.GetPosts());
    }
    [HttpGet(ApiRoutes.Posts.Get)]
    public IActionResult Get([FromRoute] Guid postId) {
        var post = _postService.GetPostById(postId);
        if (post == null) {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpPost(ApiRoutes.Posts.Create)]
    public IActionResult Create([FromBody] CreatePostRequest postRequest) {
        var post = new Post { Id = Guid.NewGuid(), Name = postRequest.Name };
        if (!_postService.AddPost(post))
            return StatusCode(StatusCodes.Status500InternalServerError);
        var baseUrl = $"{Request.Scheme}://{Request.Host.ToUriComponent()}";
        var locationUrl = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());
        var response = new PostResponse { Id = post.Id, Name = post.Name };
        return Created(locationUrl, response);
    }

    [HttpPut(ApiRoutes.Posts.Update)]
    public IActionResult Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest postRequest) {
        var post = new Post { Id = postId, Name = postRequest.Name };
        if (_postService.UpdatePost(post))
            return Ok();
        return NotFound();
    }
}
