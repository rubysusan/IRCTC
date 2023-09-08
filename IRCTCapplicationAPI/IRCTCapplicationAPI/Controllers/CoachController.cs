using IRCTCapplicationAPI.Request.Query.GetAllCoach;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController:ControllerBase
    {
        private readonly IMediator _mediator;
        public CoachController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get")]
        public async Task<ActionResult<bool>> GetAllCoach([FromQuery] GetAllCoachQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
