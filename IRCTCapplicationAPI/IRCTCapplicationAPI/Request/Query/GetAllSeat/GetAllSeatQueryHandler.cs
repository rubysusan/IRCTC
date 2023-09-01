using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllSeat
{
    public class GetAllSeatQueryHandler : IRequestHandler<GetAllSeatQuery, List<Seat>>
    {
        private readonly IrctcContext _context;
        public GetAllSeatQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<Seat>> Handle(GetAllSeatQuery query, CancellationToken cancellationToken)
        {
            return _context.Seat.ToList();
        }
    }
}
