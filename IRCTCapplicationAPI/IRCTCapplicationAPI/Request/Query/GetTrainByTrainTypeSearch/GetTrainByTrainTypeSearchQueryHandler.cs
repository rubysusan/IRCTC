using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetTrainByTrainTypeSearch
{
    public class GetTrainByTrainTypeSearchQueryHandler : IRequestHandler<GetTrainByTrainTypeSearchQuery, List<ViewTrainByTrainTypeSearch>>
    {
        private readonly IrctcContext _context;
        public GetTrainByTrainTypeSearchQueryHandler(IrctcContext context)
        {
            _context = context;
        }
        public async Task<List<ViewTrainByTrainTypeSearch>> Handle(GetTrainByTrainTypeSearchQuery request, CancellationToken cancellationToken)
        {
            return await _context.Train.Where(x => x.FromStation.StationName == request.FromStationName &&
           x.ToStation.StationName == request.ToStationName && x.Date.Date == request.Date && x.TrainClasses.Select(x => x.Coach.CoachName).Contains(request.CoachName) && x.TrainType.TypeName==request.TypeName)
                .Select(x => new ViewTrainByTrainTypeSearch
                {
                    TrainId = x.TrainId,
                    TrainName = x.TrainName,
                    FromStatioinName = x.FromStation.StationName,
                    ToStatioinName = x.ToStation.StationName,
                    Date = x.Date.Date,
                    DepartureTime = x.DepartureTime,
                    ReachingTime = x.ReachingTime

                }).ToListAsync();
        }
    }
}
