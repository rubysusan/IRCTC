using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllSeat
{
    public class GetAllSeatQuery:IRequest<List<Seat>>
    {
    }
}
