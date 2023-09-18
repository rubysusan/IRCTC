using IRCTC.Repository.Context;
using IRCTCapplicationAPI.Request.Command.UpdateSeats;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.UpdatePassengerStatus
{
    public class UpdatePassengerStatusCommandHandler : IRequestHandler<UpdatePassengerStatusCommand, bool>
    {
        private readonly IrctcContext _context;
        public UpdatePassengerStatusCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(UpdatePassengerStatusCommand command, CancellationToken cancellationtoken)
        {
            _context.Passenger.FirstOrDefault(x => x.PassengerId == command.Id).UpdatePassenger(true);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
