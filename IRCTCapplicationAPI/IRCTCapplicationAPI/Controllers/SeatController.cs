﻿using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Command.AddSeat;
using IRCTCapplicationAPI.Request.Command.UpdateSeats;
using IRCTCapplicationAPI.Request.Command.UpdateUserById;
using IRCTCapplicationAPI.Request.Query.GetAllSeat;
using IRCTCapplicationAPI.Request.Query.GetSeatForPassenger;
using IRCTCModel.Models;
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
        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateSeatBySeatId([FromBody] UpdateSeatBySeatIdCommand command)
        { return Ok(await _mediator.Send(command)); }


    }
}
