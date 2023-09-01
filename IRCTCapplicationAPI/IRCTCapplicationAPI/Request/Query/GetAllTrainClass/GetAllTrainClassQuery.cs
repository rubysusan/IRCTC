using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllTrainClass
{
    public class GetAllTrainClassQuery:IRequest<List<TrainClass>>
    {
    }
}
