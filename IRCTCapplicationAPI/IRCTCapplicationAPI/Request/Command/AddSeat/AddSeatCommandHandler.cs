using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Command.AddSeat
{
    public class AddSeatCommandHandler : IRequestHandler<AddSeatCommand, bool>
    {
        private readonly IrctcContext _context;
        public AddSeatCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<bool> Handle(AddSeatCommand command, CancellationToken cancellationToken)
        {
            Seat seat = new Seat();
            seat.SeatNumber = command.SeatNumber;
            seat.SeatTypeId = command.SeatTypeId;
            seat.TrainClassId = command.TrainClassId;
            seat.SeatStatusId = command.SeatStatusId;

            _context.Seat.Add(seat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
