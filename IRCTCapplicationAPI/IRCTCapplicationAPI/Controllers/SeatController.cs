using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Command.AddSeat;
using IRCTCapplicationAPI.Request.Query.GetAllSeat;
using IRCTCapplicationAPI.Request.Query.GetSeatForPassenger;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddSeat([FromBody] AddSeatCommand command)

        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("get")]
        public async Task<ActionResult<bool>> GetAllSeat([FromQuery] GetAllSeatQuery query)
        {
            { return Ok(await _mediator.Send(query)); }
        }
        [HttpGet("get-seat-for-passenger")]
        public async Task<ActionResult<List<ViewSeatForPassenger>>> GetSeatForPassenger([FromQuery] GetSeatForPassengerQuery query)
        {
            return Ok(await _mediator.Send(query));
        }


    }
}
