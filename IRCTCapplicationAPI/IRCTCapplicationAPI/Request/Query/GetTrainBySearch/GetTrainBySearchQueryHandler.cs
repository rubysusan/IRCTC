﻿using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            
            return await _context.Train.Where(x=>x.TrainStops.Select(x=>x.Station.StationId).Contains(request.FromStationId) &&
           x.TrainStops.Select(x => x.Station.StationId).Contains(request.ToStationId) && x.Date.Date == request.Date && EF.Functions.DateDiffHour(DateTime.Now, x.TrainStops.Where(y => y.Station.StationId == request.FromStationId).Select(z => z.ReachingTime).SingleOrDefault())>2  && x.TrainClasses.Select(x => x.Coach.CoachId).Contains(request.CoachId))
                .Select(x=>new ViewTrainBySearch
                {
                    TrainId = x.TrainId,
                    TrainName = x.TrainName,
                    FromStationName = x.TrainStops.Where(y => y.Station.StationId == request.FromStationId).Select(z => z.Station.StationName).SingleOrDefault(),
                    ToStationName= x.TrainStops.Where(y => y.Station.StationId == request.ToStationId).Select(z => z.Station.StationName).SingleOrDefault(),
                    FromStationId= x.TrainStops.Where(y => y.Station.StationId == request.FromStationId).Select(z => z.TrainStopId).SingleOrDefault(),
                    ToStationId = x.TrainStops.Where(y => y.Station.StationId == request.ToStationId).Select(z => z.TrainStopId).SingleOrDefault(),
                    Date = x.Date.Date,
                    DepartureTime = x.TrainStops.Where(y => y.Station.StationId == request.FromStationId).Select(z => z.ReachingTime).SingleOrDefault(),
                    ReachingTime = x.TrainStops.Where(y => y.Station.StationId == request.ToStationId).Select(z => z.ReachingTime).SingleOrDefault()

                }).ToListAsync();
        }
    }
}
//&& DateTime.Now < x.DepartureTime.AddHours(-2)