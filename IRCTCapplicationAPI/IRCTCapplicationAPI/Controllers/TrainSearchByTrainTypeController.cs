using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetTrainBySearch;
using IRCTCapplicationAPI.Request.Query.GetTrainByTrainTypeSearch;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRCTCapplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainSearchByTrainTypeController:ControllerBase

    {
        private readonly IMediator _mediator;
        public TrainSearchByTrainTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("train-search-by-type")]
        public async Task<ActionResult<List<ViewTrainByTrainTypeSearch>>> SearchTrainByTrainType([FromQuery] GetTrainByTrainTypeSearchQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
