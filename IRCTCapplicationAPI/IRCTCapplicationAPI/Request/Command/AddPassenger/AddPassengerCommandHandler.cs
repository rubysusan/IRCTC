using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Command.AddBooking;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddPassenger
{
    public class AddPassengerCommandHandler:IRequestHandler<AddPassengerCommand,bool>
    {
        private readonly IrctcContext _context;
        public AddPassengerCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(AddPassengerCommand command, CancellationToken cancellationToken)
        {
            Passenger passenger = new Passenger(command.PassengerName, command.SeatId, command.BookingId,false);
            _context.Passenger.Add(passenger);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
