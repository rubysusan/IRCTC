using MediatR;

namespace IRCTCapplicationAPI.DTO
{
    public class ViewAvailableSeats
    {
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public int Seats { get; set; }
    }
}
