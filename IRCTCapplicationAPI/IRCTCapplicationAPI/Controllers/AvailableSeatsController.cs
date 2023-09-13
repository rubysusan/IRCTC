using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetAvailableSeats;
using IRCTCapplicationAPI.Request.Query.GetSeatForPassenger;
using IRCTCapplicationAPI.Request.Query.GetTrainBySearch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableSeatsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AvailableSeatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<ViewAvailableSeats>>> GetAvailableSeats([FromQuery] GetAvailableSeatsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("get-seat-for-passenger")]
        public async Task<ActionResult<List<ViewSeatForPassenger>>> GetSeatForPassenger([FromQuery] GetSeatForPassengerQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
