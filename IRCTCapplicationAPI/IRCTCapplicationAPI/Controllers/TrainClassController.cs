using IRCTCapplicationAPI.Request.Command.AddTrainClass;
using IRCTCapplicationAPI.Request.Query.GetAllTrainClass;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainClassController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainClassController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddTrainClass")]
        public async Task<ActionResult<bool>> AddTrainClass([FromBody] AddTrainClassCommand command)
        { 
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetAllTrainClass")]
        public async Task<ActionResult<bool>> GetAllTrainClass([FromQuery] GetAllTrainClassQuery query)
        { return Ok(await _mediator.Send(query)); }
    }
}
