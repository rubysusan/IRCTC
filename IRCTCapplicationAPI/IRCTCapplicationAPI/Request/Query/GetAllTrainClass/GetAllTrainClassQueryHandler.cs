using IRCTC.Repository.Context;
using IRCTCModel.Models;
using MediatR;

namespace IRCTCapplicationAPI.Request.Query.GetAllTrainClass
{
    public class GetAllTrainClassQueryHandler : IRequestHandler<GetAllTrainClassQuery, List<TrainClass>>

    {
        private readonly IrctcContext _context;
        public GetAllTrainClassQueryHandler(IrctcContext context)

        {
            _context = context;
        }

        public async Task<List<TrainClass>> Handle(GetAllTrainClassQuery query, CancellationToken cancellationToken)
        {
            return _context.TrainClass.ToList();
        }
    }
}
