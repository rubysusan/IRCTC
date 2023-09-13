using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetPastBookings
{
    public class GetPastBookingsQuery:IRequest<List<ViewBookingHistory>>
    {
        public int UserId { get; set; }
    }
}
