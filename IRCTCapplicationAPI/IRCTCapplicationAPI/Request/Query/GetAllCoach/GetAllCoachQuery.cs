using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllCoach
{
    public class GetAllCoachQuery:IRequest<List<Coach>>
    {
    }
}
