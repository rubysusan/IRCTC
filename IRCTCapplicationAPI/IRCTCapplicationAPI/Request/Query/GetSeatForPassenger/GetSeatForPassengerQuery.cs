using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetSeatForPassenger
{
    public class GetSeatForPassengerQuery:IRequest<List<ViewSeatForPassenger>>
    {
        public int SeatTypeId { get; set; }
        public int TrainClassId { get; set;}
    }
}
