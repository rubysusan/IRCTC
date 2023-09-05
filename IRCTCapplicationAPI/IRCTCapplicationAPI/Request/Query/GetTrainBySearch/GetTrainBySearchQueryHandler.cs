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
           return await _context.Train.Where(x=>x.FromStation.StationName==request.FromStationName &&
           x.ToStation.StationName == request.ToStationName && x.Date.Date==request.Date && x.TrainClasses.Select(x=>x.Coach.CoachName).ToString()==request.CoachName)
                .Select(x=>new ViewTrainBySearch
                {
                    TrainId = x.TrainId,
                    TrainName = x.TrainName,
                    FromStatioinName = x.FromStation.StationName,
                    ToStatioinName= x.ToStation.StationName,
                    Date = x.Date.Date,
                    DepartureTime=x.DepartureTime,
                    ReachingTime=x.ReachingTime

                }).ToListAsync();
        }
    }
}
