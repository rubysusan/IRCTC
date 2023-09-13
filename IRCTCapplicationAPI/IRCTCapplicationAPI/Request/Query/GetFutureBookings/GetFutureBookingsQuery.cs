using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetFutureBookings
{
    public class GetFutureBookingsQuery : IRequest<List<ViewBookingHistory>>
    {
        public int UserId { get; set; }
    }
}
