using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetCharge;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetChargeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GetChargeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<ViewCharge>>> GetCharge([FromQuery] GetChargeQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
