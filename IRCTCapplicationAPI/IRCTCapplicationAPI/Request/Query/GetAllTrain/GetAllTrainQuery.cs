using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllTrain
{
    public class GetAllTrainQuery:IRequest<List<Train>>
    {
    }
}
