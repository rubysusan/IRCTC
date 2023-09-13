using IRCTCapplicationAPI.Request.Command.AddTrainClass;
using IRCTCapplicationAPI.Request.Query.GetAllTrainClass;
using IRCTCapplicationAPI.Request.Query.GetTrainClassId;
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
        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddTrainClass([FromBody] AddTrainClassCommand command)
        { 
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("get")]
        public async Task<ActionResult<bool>> GetAllTrainClass([FromQuery] GetAllTrainClassQuery query)
        { return Ok(await _mediator.Send(query)); }
        [HttpGet("get-train-class-id")]
        public async Task<ActionResult<bool>> GetTrainClassId([FromQuery] GetTrainClassIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
