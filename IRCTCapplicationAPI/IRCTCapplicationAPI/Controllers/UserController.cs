using IRCTCapplicationAPI.Request.Command.AddUser;
using IRCTCapplicationAPI.Request.Command.AddUserType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<bool>> AddUser([FromBody] AddUserCommand command)
        { return Ok(await _mediator.Send(command)); }
    }

}

