using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Command.AddBooking;
using IRCTCapplicationAPI.Request.Command.AddPassenger;
using IRCTCapplicationAPI.Request.Query.GetPassengerByTrainId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PassengerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddPassenger([FromBody] AddPassengerCommand command)

        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("get-for-tte")]
        public async Task<ActionResult<List<ViewPassenger>>> GetPassenger([FromQuery] GetPassengerByTrainIdQuery query)

        {
            return Ok(await _mediator.Send(query));
        }
    }
}