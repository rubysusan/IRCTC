using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddBooking
{
    public class AddBookingCommandHandler : IRequestHandler<AddBookingCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddBookingCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(AddBookingCommand command, CancellationToken cancellationToken)
        {
            Booking booking = new Booking(command.TrainClassId,command.FromStop,command.ToStop,
                command.Count,command.TotalCost,command.UserId,command.BookingStatusId);
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
