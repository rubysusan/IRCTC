using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllStation
{
    public class GetAllStationQuery : IRequest<List<Station>>
    {
    }
}
