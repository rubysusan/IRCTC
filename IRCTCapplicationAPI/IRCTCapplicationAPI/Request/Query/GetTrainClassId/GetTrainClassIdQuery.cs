using IRCTCapplicationAPI.DTO;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetTrainClassId
{
    public class GetTrainClassIdQuery:IRequest<List<ViewTrainClassId>>
    {
        public int TrainId { get; set; }
        public int CoachId { get; set; }
    }
}
