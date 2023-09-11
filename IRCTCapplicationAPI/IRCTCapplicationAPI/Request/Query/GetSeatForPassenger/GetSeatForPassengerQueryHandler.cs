using IRCTC.Repository.Context;
using IRCTCapplicationAPI.DTO;
using IRCTCapplicationAPI.Request.Query.GetTrainBySearch;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IRCTCapplicationAPI.Request.Query.GetSeatForPassenger
{
    public class GetSeatForPassengerQueryHandler : IRequestHandler<GetSeatForPassengerQuery, List<ViewSeatForPassenger>>
    {
        private readonly IrctcContext _context;
        public GetSeatForPassengerQueryHandler(IrctcContext context)
        {
            _context = context;
        }
        public async Task<List<ViewSeatForPassenger>> Handle(GetSeatForPassengerQuery request, CancellationToken cancellationToken)
        {
            return await _context.Seat.Where(x => x.SeatTypeId == request.SeatTypeId && x.SeatStatusId ==2 && x.TrainClassId==request.TrainClassId)
                .Select(x => new ViewSeatForPassenger
            {
                SeatId = x.SeatId,
                SeatName = x.SeatNumber
            }).ToListAsync();
        }
    }
}
