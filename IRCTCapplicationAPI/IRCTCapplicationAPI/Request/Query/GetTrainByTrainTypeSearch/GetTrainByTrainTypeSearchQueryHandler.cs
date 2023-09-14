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
            return await _context.Train.Where(x => x.TrainStops.Select(x => x.Station.StationId).Contains(request.FromStationId) &&
           x.TrainStops.Select(x => x.Station.StationId).Contains(request.ToStationId) && x.Date.Date == request.Date &&
             x.TrainClasses.Select(x => x.Coach.CoachId).Contains(request.CoachId) && x.TrainType.TrainTypeID == request.TypeId)
                .Select(x => new ViewTrainByTrainTypeSearch
                {
                    TrainId = x.TrainId,
                    TrainName = x.TrainName,
                    FromStationName = x.TrainStops.Where(y => y.Station.StationId == request.FromStationId).Select(z => z.Station.StationName).SingleOrDefault(),
                    ToStationName = x.TrainStops.Where(y => y.Station.StationId == request.ToStationId).Select(z => z.Station.StationName).SingleOrDefault(),
                    FromStationId = x.TrainStops.Where(y => y.Station.StationId == request.FromStationId).Select(z => z.TrainStopId).SingleOrDefault(),
                    ToStationId = x.TrainStops.Where(y => y.Station.StationId == request.ToStationId).Select(z => z.TrainStopId).SingleOrDefault(),
                    Date = x.Date.Date,
                    DepartureTime = x.TrainStops.Where(y => y.Station.StationId == request.FromStationId).Select(z => z.ReachingTime).SingleOrDefault(),
                    ReachingTime = x.TrainStops.Where(y => y.Station.StationId == request.ToStationId).Select(z => z.ReachingTime).SingleOrDefault()

                }).ToListAsync();
        }
    }
}
// && x.TrainType.TypeName==request.TypeName
//DateTime.Now < DateTime.Parse(x.TrainStops.Where(y => y.Station.StationId == request.FromStationId).Select(z => z.ReachingTime).SingleOrDefault().ToString()).AddHours(-2)