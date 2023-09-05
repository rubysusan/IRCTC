using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Command.AddTrainClass;
using IRCTCapplicationAPI.Request.Query.GetAllTrainClass;
using IRCTCapplicationAPI.Request.Query.GetTrainBySearch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TrainSearchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrainSearchController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("SearchTrain")]
        public async Task<ActionResult<List<ViewTrainBySearch>>> SearchTrain([FromQuery] GetTrainBySearchQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
