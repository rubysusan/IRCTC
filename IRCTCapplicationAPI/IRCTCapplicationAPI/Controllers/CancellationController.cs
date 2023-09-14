using IRCTCapplicationAPI.Request.Command.Cancellation;
using IRCTCapplicationAPI.Request.Command.UpdateSeats;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancellationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CancellationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("cancel")]
        public async Task<ActionResult<bool>> CancelSeat([FromBody] CancellationCommand command)
        { return Ok(await _mediator.Send(command)); }
    }
    
}
