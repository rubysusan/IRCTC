using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddPassenger
{
    public class AddPassengerCommand:IRequest<bool>
    {
        public string PassengerName { get; set; }
        public int SeatId { get; set; }
        public int BookingId { get; set; }
    }
}
