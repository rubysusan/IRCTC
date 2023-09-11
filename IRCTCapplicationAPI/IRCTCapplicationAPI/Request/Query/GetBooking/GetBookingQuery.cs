using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetBooking
{
    public class GetBookingQuery:IRequest<List<ViewBooking>>
    {
    }
}
