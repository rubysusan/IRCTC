using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetPastBookings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetFutureBookings
{
    public class GetFutureBookingsQueryHandler : IRequestHandler<GetFutureBookingsQuery, List<ViewBookingHistory>>
    {
        private readonly IrctcContext _context;
        public GetFutureBookingsQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<ViewBookingHistory>> Handle(GetFutureBookingsQuery request, CancellationToken cancellationToken)
        {


            return await _context.Booking.Where(x => x.UserId == request.UserId && x.FromTrainStop.ReachingTime >= DateTime.Now)
                .Select(x => new ViewBookingHistory
                {
                    BookingId = x.BookingId,
                    Train = x.TrainClass.Train.TrainName,
                    Coach = x.TrainClass.Coach.CoachName,
                    FromStation = x.FromTrainStop.Station.StationName,
                    ToStation = x.ToTrainStop.Station.StationName,
                    Count = x.Count,
                    Total = x.TotalCost,
                    BookingStatus=x.BookingStatus.Status

                }).ToListAsync();
        }
    }
}
