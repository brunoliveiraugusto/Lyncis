using Lyncis.Application.Posts.Commands.CreatePost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lyncis.Post.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand command)
        {
            var postId = await mediator.Send(command);
            return Ok(new { Id = postId });
        }
    }
}
