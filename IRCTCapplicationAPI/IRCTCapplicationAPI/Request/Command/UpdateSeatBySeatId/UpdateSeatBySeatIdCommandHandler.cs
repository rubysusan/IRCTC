using IRCTC.Repository.Context;
using IRCTCModel.Enums;
using IRCTCModel.Models;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IRCTCapplicationAPI.Request.Command.UpdateSeats
{
    public class UpdateSeatBySeatIdCommandHandler : IRequestHandler<UpdateSeatBySeatIdCommand, List<Seat>>
    {
        private readonly IrctcContext _context;
        public UpdateSeatBySeatIdCommandHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<Seat>> Handle(UpdateSeatBySeatIdCommand request, CancellationToken cancellationtoken)
        {
            
            _context.Seat.FirstOrDefault(x => x.SeatId == request.SeatId).SeatUpdate((int)SeatStatusEnum.Confirmed); ;
            await _context.SaveChangesAsync();
            return _context.Seat.ToList();
        }
    }
}
