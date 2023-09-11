using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Command.AddUser;
using IRCTCapplicationAPI.Request.Command.UpdateUserById;
using IRCTCapplicationAPI.Request.Query.GetAllUser;
using IRCTCapplicationAPI.Request.Query.GetUserById;
using IRCTCapplicationAPI.Request.Query.GetUserOnLogin;
using IRCTCModel.Models;
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
        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddUser([FromBody] AddUserCommand command)
        { return Ok(await _mediator.Send(command)); }
        [HttpGet("get")]
        public async Task<ActionResult<bool>> GetAllUser([FromQuery] GetAllUserQuery command)
        { return Ok(await _mediator.Send(command)); }

        [HttpGet("get-on-login")]
        public async Task<ActionResult<List<ViewUserId>>> GetUserOnLogin([FromQuery] GetUserOnLoginQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("get-by-id")]
        public async Task<ActionResult<List<ViewUser>>> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPut("update")]
        public async Task<ActionResult<List<User>>> UpdateUserById([FromBody] UpdateUserByIdCommand command)
        { return Ok(await _mediator.Send(command)); }
    }

}

