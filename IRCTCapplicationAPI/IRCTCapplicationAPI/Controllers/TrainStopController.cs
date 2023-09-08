using IRCTCapplicationAPI.Request.Command.AddStation;
using IRCTCapplicationAPI.Request.Command.AddTrainStop;
using IRCTCapplicationAPI.Request.Query.GetAllStation;
using IRCTCapplicationAPI.Request.Query.GetAllTrainStop;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainStopController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainStopController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddTrainStop([FromBody] AddTrainStopCommand command)
        { return Ok(await _mediator.Send(command)); }
        [HttpGet("get")]
        public async Task<ActionResult<bool>> GetAllTrainStop([FromQuery] GetAllTrainStopQuery query)
        { return Ok(await _mediator.Send(query)); }
    }
}
