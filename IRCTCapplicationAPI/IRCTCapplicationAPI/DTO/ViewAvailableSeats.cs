using MediatR;

namespace IRCTCapplicationAPI.DTO
{
    public class ViewAvailableSeats
    {
        public string CoachName { get; set; }
        public int Seats { get; set; }
    }
}
