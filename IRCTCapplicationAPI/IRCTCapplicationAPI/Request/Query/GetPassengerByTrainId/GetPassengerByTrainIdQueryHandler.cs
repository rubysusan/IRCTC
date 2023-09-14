using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetFutureBookings;
using IRCTCModel.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetPassengerByTrainId
{
    public class GetPassengerByTrainIdQueryHandler:IRequestHandler<GetPassengerByTrainIdQuery, List<ViewPassenger>>
    {
        private readonly IrctcContext _context;
        public GetPassengerByTrainIdQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<ViewPassenger>> Handle(GetPassengerByTrainIdQuery request, CancellationToken cancellationToken)
        { 
            return await _context.Passenger.Where(x=>x.Seat.TrainClass.TrainId==request.TrainId && x.Seat.SeatStatusId==(int)SeatStatusEnum.Confirmed
            && x.Booking.BookingStatusId==(int)BookingStatusEnum.Confirmed).Select(x=>new ViewPassenger
            {
                PassengerId=x.PassengerId,
                PassengerName=x.PassengerName,
                SeatId=x.SeatId,
                CoachName=x.Seat.TrainClass.Coach.CoachName,
                BookingId=x.BookingId
            }).ToListAsync();
        }
    }
}
