using IRCTCapplicationAPI.Request.Command.AddTrainType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainTypeController:ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddTrainType")]
        public async Task<ActionResult<bool>> AddTrainType([FromBody] AddTrainTypeCommand command)
        {
             return Ok(await _mediator.Send(command)); 
        }
    }
}
