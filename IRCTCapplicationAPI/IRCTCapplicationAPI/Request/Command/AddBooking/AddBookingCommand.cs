using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddBooking
{
    public class AddBookingCommand : IRequest<bool>
    {
        public int TrainClassId { get; set; }
        public int FromStop { get; set; }
        public int ToStop { get; set; } 
        public int Count { get; set; }
        public int TotalCost { get; set; }
        public int UserId { get; set; }
        public int BookingStatusId { get; set; }    
    }
}
