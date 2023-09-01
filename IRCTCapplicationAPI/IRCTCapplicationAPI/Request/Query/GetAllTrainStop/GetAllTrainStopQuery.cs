using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllTrainStop
{
    public class GetAllTrainStopQuery:IRequest<List<TrainStop>>
    {
    }
}
