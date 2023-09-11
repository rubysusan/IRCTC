using IRCTCapplicationAPI.Request.Command.AddBooking;
using IRCTCapplicationAPI.Request.Command.AddSeat;
using IRCTCapplicationAPI.Request.Query.GetAllSeat;
using IRCTCapplicationAPI.Request.Query.GetBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddBooking([FromBody] AddBookingCommand command)

        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("get")]
        public async Task<ActionResult<bool>> GetAllBooking([FromQuery] GetBookingQuery query)
        {
            { return Ok(await _mediator.Send(query)); }
        }
    }
}
