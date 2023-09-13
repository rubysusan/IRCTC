using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetPassengerByTrainId
{
    public class GetPassengerByTrainIdQuery:IRequest<List<ViewPassenger>>
    {
        public int TrainId { get; set; }
    }
}
