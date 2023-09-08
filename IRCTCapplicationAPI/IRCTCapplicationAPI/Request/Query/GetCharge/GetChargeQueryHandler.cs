using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetTrainBySearch;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetCharge
{
    public class GetChargeQueryHandler : IRequestHandler<GetChargeQuery, List<ViewCharge>>
    {
        private readonly IrctcContext _context;
        public string FromStationCount;
        public int FromCount;
        public string ToStationCount;
        public int ToCount;
        public GetChargeQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<ViewCharge>> Handle(GetChargeQuery request, CancellationToken cancellationToken)
        {
            FromCount = _context.TrainStop.Where(x => x.TrainId == request.TrainId && x.Station.StationId == request.FromStationId).Select(x => x.StationCount).SingleOrDefault();
            ToCount = _context.TrainStop.Where(x => x.TrainId == request.TrainId && x.Station.StationId == request.ToStationId).Select(x => x.StationCount).SingleOrDefault();
            return await _context.TrainClass.Where(x => x.TrainId == request.TrainId && x.Coach.CoachId== request.CoachId).Select(x => new ViewCharge
                { Charge = x.Coach.BaseCharge + ((ToCount-FromCount) *10)
                    

                }).ToListAsync();
        }
    }
}
