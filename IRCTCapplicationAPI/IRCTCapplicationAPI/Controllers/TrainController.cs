using IRCTCapplicationAPI.Request.Command.AddTrain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddTrain")]
        public async Task<ActionResult<bool>> AddTrain([FromBody] AddTrainCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
