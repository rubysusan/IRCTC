using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.UpdateSeats
{
    public class UpdateSeatBySeatIdCommand : IRequest<List<Seat>>
    {
        public int SeatId { get; set; }
       
    }
}
