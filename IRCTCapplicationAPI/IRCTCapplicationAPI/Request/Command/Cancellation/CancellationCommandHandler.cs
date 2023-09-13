using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Command.UpdateSeats;
using IRCTCModel.Enums;
using IRCTCModel.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IRCTCapplicationAPI.Request.Command.Cancellation
{
    public class CancellationCommandHandler : IRequestHandler<CancellationCommand, bool>
    {
        private readonly IrctcContext _context;
        public CancellationCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(CancellationCommand request, CancellationToken cancellationtoken)
        {

            var book = _context.Booking.FirstOrDefault(x => x.BookingId == request.BookingId);
            book.BookingStatusUpdate((int)BookingStatusEnum.Cancelled);
            var pass = book.Passengers.Select(x => x.Seat).ToList();
            if (pass.Any())
            { pass.ForEach(x => x.SeatUpdate((int)SeatStatusEnum.TicketCancelled)); }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
