using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAvailableSeats
{
    public class GetAvailableSeatsQuery:IRequest<List<ViewAvailableSeats>>
    {
        public int TrainId { get; set; }

    }
}
