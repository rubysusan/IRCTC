using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Query.GetAllUser;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllStation
{
    public class GetAllStationQueryHandler : IRequestHandler<GetAllStationQuery, List<Station>>
    {

        private readonly IrctcContext _context;
        public GetAllStationQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<Station>> Handle(GetAllStationQuery query, CancellationToken cancellationToken)
        {


            return _context.Station.ToList();
        }
    }
}
