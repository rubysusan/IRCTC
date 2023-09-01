using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddSeat
{
    public class AddSeatCommand:IRequest<bool>
    {
        public string SeatNumber { get; set; }
        public int SeatTypeId { get; set; }
        
        public int TrainClassId { get; set; }

        public int SeatStatusId { get; set; }
    }
}
