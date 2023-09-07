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
            return await _context.Train.Where(x => x.TrainStops.Select(x => x.Station.StationName).Contains(request.FromStationName) &&
           x.TrainStops.Select(x => x.Station.StationName).Contains(request.ToStationName) && x.Date.Date == request.Date &&
           EF.Functions.DateDiffHour(DateTime.Now,x.TrainStops.Where(y => y.Station.StationName == request.FromStationName).Select(z => z.ReachingTime).SingleOrDefault()) >2 && x.TrainClasses.Select(x => x.Coach.CoachName).Contains(request.CoachName) && x.TrainType.TypeName == request.TypeName)
                .Select(x => new ViewTrainByTrainTypeSearch
                {
                    TrainId = x.TrainId,
                    TrainName = x.TrainName,
                    FromStationName = request.FromStationName,
                    ToStationName = request.ToStationName,
                    Date = x.Date.Date,
                    DepartureTime = x.TrainStops.Where(y => y.Station.StationName == request.FromStationName).Select(z => z.ReachingTime).SingleOrDefault(),
                    ReachingTime = x.TrainStops.Where(y => y.Station.StationName == request.ToStationName).Select(z => z.ReachingTime).SingleOrDefault()

                }).ToListAsync();
        }
    }
}
// && x.TrainType.TypeName==request.TypeName