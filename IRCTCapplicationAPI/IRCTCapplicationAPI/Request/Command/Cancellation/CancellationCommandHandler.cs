using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Command.UpdateSeats;
using IRCTCModel.Enums;
using IRCTCModel.Models;
using MediatR;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
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

            var book = _context.Booking
                .Include( x => x.Passengers)
                .ThenInclude(x => x.Seat)
                .FirstOrDefault(x => x.BookingId == request.BookingId);

            if (book is null)
            { 
                return false; 
            }


            book!.BookingStatusUpdate((int)BookingStatusEnum.Cancelled);

            foreach (var passenger in book.Passengers)
            {
                passenger.Seat.SeatUpdate((int)SeatStatusEnum.TicketCancelled);
            }
               
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
