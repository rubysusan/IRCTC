using IRCTCapplicationAPI.Request.Command.AddStation;
using IRCTCapplicationAPI.Request.Command.AddUser;
using IRCTCapplicationAPI.Request.Query.GetAllStation;
using IRCTCapplicationAPI.Request.Query.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddStation")]
        public async Task<ActionResult<bool>> AddStation([FromBody] AddStationCommand command)
        { return Ok(await _mediator.Send(command)); }
        [HttpGet("GetAllStation")]
        public async Task<ActionResult<bool>> GetAllStation([FromQuery] GetAllStationQuery query)
        { return Ok(await _mediator.Send(query)); }
    }
