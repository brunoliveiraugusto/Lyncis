using Lyncis.Identity.Api.Contracts.Users;
using Lyncis.Identity.Application.Users.Commands.UpdateUserName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lyncis.Identity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> UpdateName(Guid id, [FromBody] UpdateUserNameRequest request)
        {
            var command = new UpdateUserNameCommand(id, request.NewName);

            var updated = await _mediator.Send(command);

            return Ok(updated);
        }

    }
}
