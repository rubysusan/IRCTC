using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetTrainBySearch
{
    public class GetTrainBySearchQueryHandler : IRequestHandler<GetTrainBySearchQuery, List<ViewTrainBySearch>>
    {
        private readonly IrctcContext _context;
        public GetTrainBySearchQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<ViewTrainBySearch>> Handle(GetTrainBySearchQuery request, CancellationToken cancellationToken)
        {
           return await _context.Train.Where(x=>x.TrainStops.Select(x=>x.Station.StationName).Contains(request.FromStationName) &&
           x.TrainStops.Select(x => x.Station.StationName).Contains(request.ToStationName) && x.Date.Date == request.Date &&
           EF.Functions.DateDiffHour(DateTime.Now,x.TrainStops.Where(y => y.Station.StationName == request.FromStationName).Select(z => z.ReachingTime).SingleOrDefault()) >2 && x.TrainClasses.Select(x => x.Coach.CoachName).Contains(request.CoachName))
                .Select(x=>new ViewTrainBySearch
                {
                    TrainId = x.TrainId,
                    TrainName = x.TrainName,
                    FromStationName = request.FromStationName,
                    ToStationName= request.ToStationName,
                    Date = x.Date.Date,
                    DepartureTime = x.TrainStops.Where(y => y.Station.StationName == request.FromStationName).Select(z => z.ReachingTime).SingleOrDefault(),
                    ReachingTime = x.TrainStops.Where(y => y.Station.StationName == request.ToStationName).Select(z => z.ReachingTime).SingleOrDefault()

                }).ToListAsync();
        }
    }
}
//&& DateTime.Now < x.DepartureTime.AddHours(-2)