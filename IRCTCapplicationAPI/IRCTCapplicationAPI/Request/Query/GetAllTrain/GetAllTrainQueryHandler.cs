using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllTrain
{
    public class GetAllTrainQueryHandler : IRequestHandler<GetAllTrainQuery, List<Train>>
    {
        private readonly IrctcContext _context;
        public GetAllTrainQueryHandler(IrctcContext context)

        {
            _context = context;
        }
        public async Task<List<Train>> Handle(GetAllTrainQuery query, CancellationToken cancellationToken)
        {
            return _context.Train.ToList();
        }
    }
}
