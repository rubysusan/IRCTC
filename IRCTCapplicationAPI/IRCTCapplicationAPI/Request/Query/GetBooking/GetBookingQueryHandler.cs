using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetAvailableSeats;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, List<ViewBooking>>
    {
        private readonly IrctcContext _context;
        public GetBookingQueryHandler(IrctcContext context)

        {
            _context = context;
        }

        public async Task<List<ViewBooking>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var lastBookingId = _context.Booking.OrderBy(x=>x.BookingId).LastOrDefault().BookingId;
            return await _context.Booking.Where(x=>x.BookingId == lastBookingId).
               Select(x => new ViewBooking
               {
                   BookingId = x.BookingId,
                   TrainClassId=x.TrainClassId,
                   FromStop = x.FromStop,
                   ToStop = x.ToStop,
                   Count = x.Count,
                   TotalCost = x.TotalCost,
                   UserId = x.UserId,

               }).ToListAsync();


        }
    }
}
