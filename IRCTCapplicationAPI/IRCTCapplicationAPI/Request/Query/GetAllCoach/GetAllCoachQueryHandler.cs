using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllCoach
{
    public class GetAllCoachQueryHandler : IRequestHandler<GetAllCoachQuery, List<Coach>>
    {
        private readonly IrctcContext _context;
        public GetAllCoachQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<Coach>> Handle(GetAllCoachQuery request, CancellationToken cancellationToken)
        {
            return _context.Coach.ToList();
        }
    }
}
