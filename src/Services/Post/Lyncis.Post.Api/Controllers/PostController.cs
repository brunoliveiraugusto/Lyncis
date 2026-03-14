using Lyncis.Post.Application.Posts.Commands.CreatePost;
using Lyncis.Post.Application.Posts.Queries.GetPostById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lyncis.Post.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand command)
        {
            var postId = await _mediator.Send(command);
            return Ok(new { Id = postId });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetPostByIdQuery(id);
            var response = await _mediator.Send(query);

            if (response is null)
                return NotFound(new { Message = $"Post with Id {id} not found" });

            return Ok(response);
        }
    }
}
